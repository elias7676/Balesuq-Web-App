using IdentityManager.Dto;
using IdentityManager.Models;

namespace IdentityManager
{
    public static class Extensions
    {
        public static Product AsDto(this Product product)
        {
            return new Product
            {
        Id = product.Id,
        Name = product.Name,
        Price = product.Price,
        CategoryId = product.CategoryId,
        Category = product.Category,
        Unit = product.Unit,
        Brand = product.Brand,
        Image = product.Image,
        CreatedDate = product.CreatedDate,
        Status = product.Status
               
            };
        }
        public static Buyer AsDto(this Buyer buyer)
        {
            return new Buyer
            {
                Id=buyer.Id,
                Name = buyer.Name,
                SubcityId = buyer.SubcityId,
                Woreda = buyer.Woreda,
                TinNo = buyer.TinNo,
                LicenseNo = buyer.LicenseNo,
                LicenseImage = buyer.LicenseImage,
                Status = buyer.Status,
                Phone = buyer.Phone
            };
        }

        public static BuyerRequest AsDto(this BuyerRequest buyerRequest)
        {
            return new BuyerRequest
            {
                Id=buyerRequest.Id,
                BuyerId = buyerRequest.BuyerId,
                Status = buyerRequest.Status

            };
        }
        public static Subcity AsDto(this Subcity subcity)
        {
            return new Subcity
            {
                Id=subcity.Id,
                Name = subcity.Name
            };
        }
        public static Category AsDto(this Category category)
        {
            return new Category
            {
                Id=category.Id,
                Name = category.Name
            };
        }
        public static ProductOrder AsDto(this ProductOrder productOrder)
        {
            return new ProductOrder
            {
                Id=productOrder.Id,
                ProductId=productOrder.ProductId,
                BuyerId=productOrder.BuyerId,
                Amount=productOrder.Amount,
                CreatedDate=productOrder.CreatedDate
               
            };
        }

    }
}