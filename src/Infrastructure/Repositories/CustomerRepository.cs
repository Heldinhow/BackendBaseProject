using FluentResults;
using Microsoft.EntityFrameworkCore;
using BackendBaseProject.Application.Interfaces;
using BackendBaseProject.Infrastructure.Data;
using BackendBaseProject.Infrastructure.Data.Entities;

namespace BackendBaseProject.Infrastructure.Repositories;

public interface ICustomerRepository
{
    Task<Result<Customer?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<Customer>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result> AddAsync(Customer entity, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(Customer entity, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

public class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Result<Customer?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var customer = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            return customer is null
                ? Result.Fail($"Customer with Id '{id}' not found")
                : Result.Ok(customer);
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error retrieving customer: {ex.Message}");
        }
    }

    public async Task<Result<IEnumerable<Customer>>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var customers = await _context.Customers
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return Result.Ok<IEnumerable<Customer>>(customers);
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error retrieving customers: {ex.Message}");
        }
    }

    public async Task<Result> AddAsync(Customer entity, CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.Customers.AddAsync(entity, cancellationToken);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error adding customer: {ex.Message}");
        }
    }

    public async Task<Result> UpdateAsync(Customer entity, CancellationToken cancellationToken = default)
    {
        try
        {
            _context.Customers.Update(entity);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error updating customer: {ex.Message}");
        }
    }

    public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var customer = await _context.Customers.FindAsync([id], cancellationToken);
            if (customer is null)
            {
                return Result.Fail($"Customer with Id '{id}' not found");
            }

            _context.Customers.Remove(customer);
            return Result.Ok();
        }
        catch (Exception ex)
        {
            return Result.Fail($"Error deleting customer: {ex.Message}");
        }
    }
}
