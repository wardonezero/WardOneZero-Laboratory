using DataFormulaLibrary.Models.Product;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace WardOneZeroCommerce.Models.Console;

public class ProductFormViewModel
{
    public Configuration Configuration { get; set; }
    public Inventory Inventory { get; set; }
    public MetaData MetaData { get; set; }
    public Product Product { get; set; }

    public ProductFormViewModel()
    {
        Configuration = new();
        Inventory = new();
        MetaData = new MetaData();
        Product = new Product();
    }
    public ProductFormViewModel(Configuration? configuration, Inventory? inventory, MetaData? metaData, Product? product)
    {
        if (configuration != null && inventory != null && metaData != null && product != null &&
            configuration.Id == product.Id && inventory.Id == product.Id && metaData.Id == product.Id)
        {
            Configuration = configuration;
            Inventory = inventory;
            MetaData = metaData;
            Product = product;
        }
        else
        {
            throw new ArgumentException("Parameters do not match");
        }
    }

    public bool Validate(ValidationMessageStore store)
    {
        store.Clear();

        bool isValid = true;
        isValid &= ValidateEntity(store, Product);
        isValid &= ValidateEntity(store, MetaData);
        isValid &= ValidateEntity(store, Inventory);
        isValid &= ValidateEntity(store, Configuration);

        return isValid;
    }

    private static bool ValidateEntity(ValidationMessageStore store, object entity)
    {
        ValidationContext context = new(entity);
        List<ValidationResult> results = [];
        bool isValid = Validator.TryValidateObject(entity, context, results, true);

        foreach (ValidationResult result in results)
        {
            foreach (string memberName in result.MemberNames)
            {
                FieldIdentifier identifier = new(entity, memberName);
                store.Add(identifier, result.ErrorMessage!);
            }
        }

        return isValid;
    }
}
