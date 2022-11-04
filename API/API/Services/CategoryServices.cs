using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ShareViewModel.DTO;
using System.Collections.Immutable;
using X.PagedList;

namespace API.Services
{
    public class CategoryServices
    {
        private ShopDbContext _context;
        public CategoryServices(ShopDbContext context)
        {
            _context = context;
        }

        //category
        public List<Category> GetAllCategories() => _context.Category.ToList();
        public AdminCategoryDTO AddCategory(AdminCategoryDTO addcategory)
        {
            var category = new Category();
            category.ID = addcategory.ID;
            category.Name = addcategory.Name;
            category.Created_by = addcategory.Created_by;
            category.Created_at = DateTime.Now;
            category.Updated_at = DateTime.Now;

            _context.Category.Add(category);
            _context.SaveChanges();

            return new AdminCategoryDTO()
            {
                ID = category.ID,
                Name = category.Name,
                Created_by = category.Created_by,
                Created_at = category.Created_at,
                Updated_at = category.Updated_at,
            };
        }

        public AdminCategoryDTO UpdateCategory(AdminCategoryDTO updatecategory, int ID)
        {
            var category = _context.Category.Where(c => c.ID == ID).FirstOrDefault();
            if (category != null)
            {
                category.Name = updatecategory.Name;
                category.Updated_at = DateTime.Now;
                _context.SaveChanges();
            }

            return new AdminCategoryDTO()
            {
                ID = category.ID,
                Name = category.Name,
                Created_by = category.Created_by,
                Created_at = category.Created_at,
                Updated_at = category.Updated_at,
            };
        }

        public int DeleteCategory(int ID)
        {

            var category = _context.Category.Where(c => c.ID == ID).FirstOrDefault();
            if (category != null)
            {
                _context.Category.Remove(category);
                _context.SaveChanges();
            }
            return 0;
        }
        public List<Products> GetProductByCategory(int ID)
        {
            //var pageNumber = page ?? 1;
            //var pageSize = 10;
            //var productList= _context.Products.OrderByDescending(x => x.ID).Where(x => x.CategoryID == ID).ToPagedList(pageNumber, pageSize).ToList();
            var productList = _context.Products.OrderByDescending(x => x.ID).Where(x => x.CategoryID == ID).ToList();
            return productList;
        }

    }
}
