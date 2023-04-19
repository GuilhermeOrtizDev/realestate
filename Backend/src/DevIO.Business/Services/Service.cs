using DevIO.Infrastructure.Requests;

namespace DevIO.Business.Services
{
   /* public class Service<V, R> where V : Validation<R> where R : Request
    {
        protected void CreateValidation(V validation, R request)
        {
            //validation.Create();
            Validation(validation, request);
        }

        private void Validation(V validation, R request)
        {
            var validator = validation.Validate(request);

            if (validator.IsValid)
                return;

            var exceptions = new List<Exception>();

            foreach (var exception in validator.Errors)
                exceptions.Add(new NullReferenceException(exception.ErrorMessage));

            throw new AggregateException("Error", exceptions);

        }
    }*/
}
