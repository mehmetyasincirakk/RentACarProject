// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;



RentalTest();
//CarTest();
//BrandTest();
//ColorTest();
static void BrandTest()
{
    BrandManager brandManager = new(new EfBrandDal());
    var result = brandManager.GetAll();
    if (result.IsSuccess == true)
    {
        foreach (var brand in result.Data)
        {
            Console.WriteLine(brand.BrandName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }

}
static void CarTest()
{
    CarManager carManager = new CarManager(new EfCarDal());
    var result = carManager.GetCarDetails();
    if (result.IsSuccess == true)
    {
        foreach (var car in result.Data)
        {
            Console.WriteLine(car.CarId + " " + car.CarName + " " + car.ColorName + " " + car.DailyPrice);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }

}
static void ColorTest()
{
    ColorManager colorManager = new(new EfColorDal());
    var result = colorManager.GetAll();
    if (result.IsSuccess == true)
    {
        foreach (var color in result.Data)
        {
            Console.WriteLine(color.ColorName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }

}
static void RentalTest()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());
    rentalManager.Add(new Rental
    {
        CarId = 1,
        CustomerId = 1,
        RentDate = new DateTime(2022, 10, 5),
        ReturnDate = new DateTime(2022, 10, 7)
    }
    );
    var result = rentalManager.GetAllUsers();
    if (result.IsSuccess == true)
    {
        foreach (var item in result.Data)
        {
            Console.WriteLine(item.CarId);
        }
    }
    
}