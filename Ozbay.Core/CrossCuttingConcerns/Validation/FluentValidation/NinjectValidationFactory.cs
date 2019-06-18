using FluentValidation;
using Ninject;
using Ninject.Modules;
using System;

namespace OZBAY.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public class NinjectValidationFactory : ValidatorFactoryBase
    {
        private IKernel _kernel;

        public NinjectValidationFactory(INinjectModule ninjectModule)
        {
            _kernel = new StandardKernel(ninjectModule);
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return (IValidator)_kernel.TryGet(validatorType);
        }
    }
}
