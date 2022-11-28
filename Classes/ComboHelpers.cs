using ECommerceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceProject.Classes
{
    public class ComboHelpers : IDisposable
    {
        private static EcommerceContext db = new EcommerceContext();

        public static List<Departaments> GetDepartaments()
        {
            var dep = db.Departaments.ToList();
            dep.Add(new Departaments
            {
                DepartamentsId = 0,
                Name = "[Selecione um Departamento]"
            });

           return dep = dep.OrderBy(d => d.Name).ToList();
        }
        public static List<City> GetCities()
        {
            var city = db.Cities.ToList();
            city.Add(new City
            {
                CityId = 0,
                Name = "[Selecione uma Cidade]"
            });

            return city = city.OrderBy(d => d.Name).ToList();
        }

        public static List<Company> GetCompany()
        {
            var company = db.Companies.ToList();
            company.Add(new Company
            {
                CompanyId = 0,
                Name = "[Selecione uma Companhia]"
            });

            return company = company.OrderBy(c => c.Name).ToList();
        }
        public static List<Category> GetCategory(int companyId)
        {
            var cat = db.Categories.Where(c => c.CompanyId == companyId).ToList();
            cat.Add(new Category
            {
                CategoryId = 0,
                Description = "[Selecione uma Categoria]"
            });

            return cat = cat.OrderBy(c => c.Description).ToList();
        }

        public static List<Customer> GetCustomer( int companyId)
        {
            var customer = db.Customers.Where(c=> c.CompanyId == companyId).ToList();
            customer.Add(new Customer
            {
                CustumerId = 0,
                FirstName = "[Selecione um Cliente]"
            });

            return customer = customer.OrderBy(c => c.FirstName).ThenBy(c=>c.LastName).ToList();
        }

        public static List<Tax> GetTaxes(int companyId)
        {
            var tax = db.Taxes.Where(c => c.CompanyId == companyId).ToList();
            tax.Add(new Tax
            {
                TaxId = 0,
                Description = "[Selecione uma Taxa]"
            });

            return tax = tax.OrderBy(c => c.Description).ToList();
        }
        public static List<Product> GetProduct(int companyId)
        {
            var product = db.Products.Where(c=> c.CompanyId == companyId).ToList();
            product.Add(new Product
            {
                ProductId = 0,
                Description = "[Selecione um Produto]"
            });

            return product = product.OrderBy(c => c.Description).ToList();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}