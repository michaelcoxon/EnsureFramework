namespace EnsureFramework.UnitTests.ValidateTests
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    using Xunit;

    public class ModelStateDictionaryTests
    {
        [Fact]
        public void Model_IsNotNull_EmptyKey()
        {
            var name = "model";
            var result = ModelStateDictionaryExtensions.GetKeyForModelStateDictionary(name);
            Assert.Empty(result);
        }

        [Fact]
        public void Model_Property_IsNotNull_WithKey()
        {
            var name = "model.MyProp";
            var result = ModelStateDictionaryExtensions.GetKeyForModelStateDictionary(name);
            Assert.Equal("MyProp", result);
        }

        [Fact]
        public void ModelState_ApplyTo_Test()
        {
            var model = new
            {
                String = "asdf",
                Number = 1
            };

            var msd = new ModelStateDictionary();

            Validate.That(model.String).IsNotNull().ApplyTo(msd);
            Validate.That(model.Number).IsGreaterThan(1).ApplyTo(msd);

            Assert.False(msd.IsValid);
        }

        [Fact]
        public void ModelState_Apply_Test()
        {
            var model = new
            {
                String = "asdf",
                Number = 1
            };

            var msd = new ModelStateDictionary();

            msd.Apply(Validate.That(model.String).IsNotNull());
            msd.Apply(Validate.That(model.Number).IsGreaterThan(1));

            Assert.False(msd.IsValid);
        }
    }
}
