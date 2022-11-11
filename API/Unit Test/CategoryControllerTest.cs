using ShareViewModel.DTO;
using API.Controllers;
using API.Interfaces;
using Moq;
using API.Models;

namespace Unit_Test
{
    public class CategoryControllerTest
    {
        private List<Category> categories = new List<Category>
        {
            new Category(){ ID = 1, Name="Johnny", Description=""},
            new Category(){ ID = 2, Name="Dang", Description=""},
            new Category(){ ID = 3, Name="Khoa", Description=""},
            new Category(){ ID = 4, Name="Pug", Description=""}
        };

        [Fact]
        public async Task GetAllCategories()
        {
            var mockService = new Mock<ICategoryService>(); //Arrange
            mockService.Setup(x => x.GetAllCategories()).ReturnsAsync(categories);
            var controller = new APIcategoryController(mockService.Object);


            var result = await controller.GetAllCategories(); //Act

            Assert.IsType<List<Category>>(result.Value); //Assert
            Assert.Equal(categories, result.Value);
        }

        [Fact]
        public async Task CreateCategory() 
        {
            var createCategory = new AdminCategoryDTO() 
            {
                Name="Johnny", Description="Dang"
            };
            var return_category = new AdminCategoryDTO() {ID=1, Name = "Johnny", Description = "Dang" };
            var mockService = new Mock<ICategoryService>();
            mockService.Setup(x => x.AddCategory(createCategory)).ReturnsAsync(return_category);
            var controller = new APIcategoryController(mockService.Object);


            var result = await controller.AddCategory(createCategory);

        
            Assert.Equal(return_category, result.Value);

        }


     
        //[Fact]
        //public async Task UpdateCategpry() 
        //{
        //    var update_category = new AdminCategoryDTO()
        //    {
        //        Name = "After",
        //        Description = "after"
        //    };

           
        //    var After_Update = new AdminCategoryDTO() {ID = 1, Name = "After", Description= "after" };
           
        //    var mockService = new Mock<ICategoryService>();
        //    mockService.Setup(x => x.UpdateCategory(update_category,1)).ReturnsAsync(After_Update);
        //    var controller = new APIcategoryController(mockService.Object);


        //    var result = await controller.UpdateCategory(update_category,1);


        //    Assert.Equal(After_Update,result.Value);
        //}
    }
}