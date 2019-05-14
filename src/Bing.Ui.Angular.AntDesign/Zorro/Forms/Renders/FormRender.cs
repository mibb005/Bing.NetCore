﻿using Bing.Ui.Angular.Base;
using Bing.Ui.Builders;
using Bing.Ui.Configs;

namespace Bing.Ui.Zorro.Forms.Renders
{
    /// <summary>
    /// 表单渲染器
    /// </summary>
    public class FormRender : AngularRenderBase
    {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化一个<see cref="FormRender"/>类型的实例
        /// </summary>
        /// <param name="config">配置</param>
        public FormRender(Config config) : base(config)
        {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder()
        {
            var builder = new FormBuilder();
            Config(builder);
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">标签生成器</param>
        private void Config(TagBuilder builder)
        {
            builder.AddAttribute("nz-form");
            ConfigContent(builder);
            ConfigId(builder);
            ConfigEvents(builder);
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        /// <param name="builder">标签生成器</param>
        protected override void ConfigId(TagBuilder builder)
        {
            if (_config.Contains(UiConst.Id))
            {
                builder.AddAttribute($"#{_config.GetValue(UiConst.Id)}", "ngForm");
            }
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        /// <param name="builder">标签生成器</param>
        private void ConfigEvents(TagBuilder builder)
        {
            builder.AddAttribute("(ngSubmit)", _config.GetValue(UiConst.OnSubmit));
        }
    }
}