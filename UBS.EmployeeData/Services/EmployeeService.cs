using MongoDB.Driver;
using System;
using UBS.EmployeeData.Abstraction;
using UBS.EmployeeData.Persistence;
using System.Collections.Generic;

namespace UBS.EmployeeData
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employee;
        public EmployeeService(IDatabaseSettings _settings)
        {
            var _client = new MongoClient(_settings.ConnectionString);
            var database = _client.GetDatabase(_settings.DatabaseName);
            _employee = database.GetCollection<Employee>(_settings.CollectionName);

        }

        public List<Employee> Get()
        {
            return _employee.Find(s => true).ToList();
        }

        public Employee GetById(string Id)
        {
            return _employee.Find<Employee>(s => s.Id == Id).First();
        }

        public Employee Insert(Employee employee)
        {

            _employee.InsertOne(employee);
            return employee;
        }

        public Employee Update(String id, Employee employee)
        {
            _employee.FindOneAndReplace<Employee>(s => s.Id == id, employee);
            return employee;

        }

        public DeleteResult Delete(string id)
        {
            return _employee.DeleteOne(s => s.Id == id);
        }

    }
}
