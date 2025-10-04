using AssetManager.Business.Interface;
using AssetManager.Data.Repository;
using AssetManager.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo) { _repo = repo; }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                return await _repo.GetAllAsync();
            }
            catch (Exception ex)
            {
               
                throw new ApplicationException("Error retrieving employees.", ex);
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            try
            {
                return await _repo.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
               
                throw new ApplicationException($"Error retrieving employee with ID {id}.", ex);
            }
        }

        public async Task AddEmployeeAsync(Employee emp)
        {
            try
            {
                await _repo.AddAsync(emp);
            }
            catch (Exception ex)
            {
               
                throw new ApplicationException("Error adding employee.", ex);
            }
        }

        public async Task UpdateEmployeeAsync(Employee emp)
        {
            try
            {
                await _repo.UpdateAsync(emp);
            }
            catch (Exception ex)
            {
               
                throw new ApplicationException("Error updating employee.", ex);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            try
            {
                await _repo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
               
                throw new ApplicationException($"Error deleting employee with ID {id}.", ex);
            }
        }
    }
}
