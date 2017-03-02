namespace Jambo.WebAPI
{
    public class MultipleOperationsWithSameVerbFilter : Swashbuckle.SwaggerGen.Generator.IOperationFilter
    {
        public void Apply(Swashbuckle.Swagger.Model.Operation operation, Swashbuckle.SwaggerGen.Generator.OperationFilterContext context)
        {
            if (operation.Parameters != null)
            {
                operation.OperationId += "By";
                foreach (var parm in operation.Parameters)
                {
                    operation.OperationId += string.Format("{0}", parm.Name);
                }
            }
        }
    }
}
