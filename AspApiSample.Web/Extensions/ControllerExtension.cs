using AspApiSample.Web.Models;
using IO.Swagger.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspApiSample.Web.Extensions
{
#nullable enable
    public static class ControllerExtension
    {
        #region ModelState
        public static IActionResult ViewWithErrors<T>(
            this Controller controller,
            T? model,
            ModelStateDictionary modelState)
            where T : ModelBase, new()
        {
            IActionResult output;

            model = SetModelData(model ?? new T(), modelState);
            output = controller.View(model);

            return output;
        }

        public static IActionResult ViewWithErrors<T>(
            this Controller controller,
            string viewName,
            T? model,
            ModelStateDictionary modelState)
            where T : ModelBase, new()
        {
            IActionResult output;

            model = SetModelData(model ?? new T(), modelState);
            output = controller.View(viewName, model);

            return output;
        }

        public static IActionResult ViewWithErrors<T>(
            this Controller controller,
            string viewName,
            string controllerName,
            T? model,
            ModelStateDictionary modelState)
            where T : ModelBase, new()
        {
            IActionResult output;

            model = SetModelData(model ?? new T(), modelState);
            output = controller.RedirectToAction(viewName, controllerName, model);

            return output;
        }

        private static T SetModelData<T>(
            T model,
            ModelStateDictionary modelState)
            where T : ModelBase
        {
            model.ResetData();
            model.Errors = modelState.GetErrorsAsStringTable();

            return model;
        }
        #endregion
        #region ApiException
        public static IActionResult ViewWithErrors<T>(
            this Controller controller,
            T? model,
            ApiException e)
            where T : ModelBase, new()
        {
            IActionResult output;

            model = SetModelData(model ?? new T(), e);
            output = controller.View(model);

            return output;
        }

        public static IActionResult ViewWithErrors<T>(
            this Controller controller,
            string viewName,
            T? model,
            ApiException e)
            where T : ModelBase, new()
        {
            IActionResult output;

            model = SetModelData(model ?? new T(), e);
            output = controller.View(viewName, model);

            return output;
        }

        public static IActionResult ViewWithErrors<T>(
            this Controller controller,
            string viewName,
            string controllerName,
            T? model,
            ApiException e)
            where T : ModelBase, new()
        {
            IActionResult output;

            model = SetModelData(model ?? new T(), e);
            output = controller.RedirectToAction(viewName, controllerName, model);

            return output;
        }

        private static T SetModelData<T>(
            T model,
            ApiException e)
            where T : ModelBase
        {
            model.ResetData();
            model.Errors = e.GetDetailTable();

            return model;
        }
        #endregion
    }
#nullable disable
}
