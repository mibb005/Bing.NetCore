﻿using Bing.Ui.Angular;
using Bing.Ui.Angular.Forms.Configs;
using Bing.Ui.Angular.Forms.Resolvers;
using Bing.Ui.Builders;
using Bing.Ui.Configs;
using Bing.Ui.Zorro.Forms.Base;
using Bing.Ui.Zorro.Forms.Builders;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Bing.Ui.Zorro.Forms.Renders
{
    /// <summary>
    /// 下拉列表渲染器
    /// </summary>
    public class SelectRender : FormControlRenderBase
    {
        /// <summary>
        /// 下拉列表配置
        /// </summary>
        private readonly SelectConfig _config;

        /// <summary>
        /// 初始化一个<see cref="SelectRender"/>类型的实例
        /// </summary>
        /// <param name="config">下拉列表配置</param>
        public SelectRender(SelectConfig config) : base(config)
        {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder()
        {
            ResolveExpression();
            var builder = new SelectWrapperBuilder();
            base.Config(builder);
            ConfigSelect(builder);
            return builder;
        }

        /// <summary>
        /// 解析属性表达式
        /// </summary>
        protected void ResolveExpression()
        {
            if (_config.Contains(UiConst.For) == false)
            {
                return;
            }

            var expression = _config.GetValue<ModelExpression>(UiConst.For);
            SelectExpressionResolver.Init(expression, _config);
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">标签生成器</param>
        private void ConfigSelect(SelectWrapperBuilder builder)
        {
            ConfigWidth(builder);
            ConfigUrl(builder);
            ConfigDataSource(builder);
            ConfigDefaultOption(builder);
            ConfigMultiple(builder);
            ConfigTemplate(builder);
            ConfigStandalone(builder);
        }

        /// <summary>
        /// 配置宽度
        /// </summary>
        /// <param name="builder">标签生成器</param>
        private void ConfigWidth(SelectWrapperBuilder builder)
        {
            builder.AddAttribute(UiConst.Width, _config.GetValue(UiConst.Width));
        }

        /// <summary>
        /// 配置Url
        /// </summary>
        /// <param name="builder">标签生成器</param>
        private void ConfigUrl(SelectWrapperBuilder builder)
        {
            builder.AddAttribute(UiConst.Url, _config.GetValue(UiConst.Url));
            builder.AddAttribute("[url]", _config.GetValue(AngularConst.BindUrl));
            builder.AddAttribute("[queryParam]", _config.GetValue(UiConst.QueryParam));
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        /// <param name="builder">标签生成器</param>
        private void ConfigDataSource(SelectWrapperBuilder builder)
        {
            AddItems();
            builder.AddAttribute("[dataSource]", _config.GetValue(UiConst.DataSource));
        }

        /// <summary>
        /// 添加项集合
        /// </summary>
        private void AddItems()
        {
            if (_config.Items.Count == 0)
            {
                return;
            }

            _config.SetAttribute(UiConst.DataSource, Bing.Utils.Json.JsonHelper.ToJson(_config.Items, true));
        }

        /// <summary>
        /// 配置默认项
        /// </summary>
        /// <param name="builder">标签生成器</param>
        private void ConfigDefaultOption(SelectWrapperBuilder builder)
        {
            builder.AddAttribute("defaultOptionText", _config.GetValue(UiConst.DefaultOptionText));
        }

        /// <summary>
        /// 配置多选
        /// </summary>
        /// <param name="builder">标签生成器</param>
        private void ConfigMultiple(SelectWrapperBuilder builder)
        {
            builder.AddAttribute("[multiple]", _config.GetBoolValue(UiConst.Multiple));
        }

        /// <summary>
        /// 配置显示模板
        /// </summary>
        /// <param name="builder">标签生成器</param>
        private void ConfigTemplate(SelectWrapperBuilder builder)
        {
            builder.AddAttribute(UiConst.Template, _config.GetValue(UiConst.Template));
        }

        /// <summary>
        /// 配置独立
        /// </summary>
        /// <param name="builder">标签生成器</param>
        private void ConfigStandalone(TagBuilder builder)
        {
            builder.AddAttribute("[standalone]", _config.GetBoolValue(UiConst.Standalone));
        }
    }
}