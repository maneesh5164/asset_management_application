using AssetManager.Data.Infrastructure;
using AssetManager.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;
        public EmployeeRepository(AppDbContext db) { _db = db; }

        public async Task<List<Employee>> GetAllAsync()
        {
            try
            {
                return await _db.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Error retrieving employees.", ex);
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            try
            {
                return await _db.Employees.FindAsync(id);
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException($"Error retrieving employee with ID {id}.", ex);
            }
        }

        public async Task AddAsync(Employee emp)
        {
            try
            {
                _db.Employees.Add(emp);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Error adding employee.", ex);
            }
        }

        public async Task UpdateAsync(Employee emp)
        {
            try
            {
                _db.Employees.Update(emp);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException("Error updating employee.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var emp = await _db.Employees.FindAsync(id);
                if (emp != null)
                {
                    _db.Employees.Remove(emp);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                
                throw new ApplicationException($"Error deleting employee with ID {id}.", ex);
            }
        }
    }
}
