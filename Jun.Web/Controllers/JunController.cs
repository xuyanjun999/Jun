using Jun.Core.Dependency;
using Jun.Core.Domain.Entity;
using Jun.Core.Dto;
using Jun.Core.Dto.RequestModel;
using Jun.Core.Helper;
using Jun.Core.Reflection;
using Jun.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jun.Web.Controllers
{
    public class JunController<T> : Controller where T : BaseEntity, new()
    {
        protected readonly ILogger _logger = null;

        public JunController()
        {
            var logFactory = IocManager.Instance.Resolve<ILoggerFactory>();
            _logger = logFactory == null ? NullLogger.Instance : logFactory.CreateLogger(this.GetType());
        }



        public virtual JsonResult Single([FromForm] SingleModel singleModel, [FromServices]IRepositoryBase repository)
        {
            RestResponseDto res = new RestResponseDto();

            T entity = repository.QueryFirst<T>(x => x.Id == singleModel.Id, singleModel.Include);

            res.Data = new object[] { entity };

            res.Success = true;

            return Json(res);
        }




        [HttpPost]
        public virtual JsonResult Create([FromBody]CreateModel<T> createModel, [FromServices]IRepositoryBase repository)
        {
            var entity = createModel.Entity;

            RestResponseDto res = new RestResponseDto();

            ReflectionUtil.TrimString(entity);

            Validate(entity);

            repository.Insert(entity);

            res.Data = new object[] { repository.QueryFirst<T>(x => x.Id == entity.Id) };

            res.Success = true;

            return Json(res);
        }


        public virtual JsonResult Delete([FromBody]DeleteModel deleteModel, [FromServices]IRepositoryBase repository)
        {
            EntityResponseDto res = new EntityResponseDto();

            Validate(deleteModel.Ids);

            int count = repository.Delete<T>(deleteModel.Ids);

            res.Success = true;

            return Json(res);
        }



        public virtual JsonResult Read([FromForm]CommonAjaxArgs args, [FromServices]IRepositoryBase repository)
        {
            EntityResponseDto res = new EntityResponseDto();

            var predicate = ExpressionUtil.GetSearchExpression(typeof(T), args.Filter) as Expression<Func<T, bool>>;

            args.PageSize = args.PageSize <= 0 ? 50 : args.PageSize;

            args.PageIndex = args.PageIndex == 0 ? 1 : args.PageIndex;

            args.SortField = string.IsNullOrWhiteSpace(args.SortField) ? EntityConst.EntityIdName : args.SortField;

            args.SortOrder = string.IsNullOrWhiteSpace(args.SortOrder) ? "desc" : args.SortOrder;

            string[] includes = args.Include;

            res.Total = repository.GetQueryExp<T>(predicate, includes).Count();
            res.Data = repository.QueryPage<T>(predicate, new Pagination() { page = args.PageIndex, rows = args.PageSize, SortField = args.SortField, SortOrder = args.SortOrder }, includes);
            res.Success = true;
            return Json(res);
        }

        [HttpPost]
        public virtual JsonResult Update([FromBody]UpdateModel<T> updateModel, [FromServices]IRepositoryBase repository)
        {
            RestResponseDto res = new RestResponseDto();

            ReflectionUtil.TrimString(updateModel.Entity);

            Validate(updateModel.Entity);

            repository.Update<T>(updateModel.Entity);

            res.Success = true;

            return Json(res);
        }

        [HttpPost]
        public virtual JsonResult BatchHanlde([FromBody]BatchModel<T> batchModel, [FromServices]IRepositoryBase repository)
        {
            RestResponseDto res = new RestResponseDto();

            var groups = batchModel.Entitys.GroupBy(x => x._state);

            foreach (var group in groups)
            {
                group.ToList().ForEach(model =>
                {
                    ReflectionUtil.TrimString(model);
                    Validate(model);
                });
                switch (group.Key)
                {
                    case "added":
                        repository.Insert<T>(group.ToArray());
                        break;
                    case "modified":
                        repository.Update<T>(group.ToArray());
                        break;
                }
            }
            res.Success = true;

            return Json(res);
        }


        public virtual void Validate(T entity)
        {
            //数据验证
        }

        public virtual void Validate(int[] ids)
        {
            //数据验证
        }

    }


}
