using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using CherrieCouture.Domain.Models;
using CherrieCoutureApi.Dtos;
using CherrieCoutureApi.EnumDto;
using CherrieCouture.Domain.Enums;
using CherrieCouture.Domain.Interfaces;
using CherrieCouture.Domain.Repository;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore;


namespace CherrieCoutureApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			//AutoMapper config
			Mapper.Initialize(cm => {
				cm.CreateMap<User, UserDto>();
				cm.CreateMap<UserDto, User>();
				cm.CreateMap<OrderDto, Order>();
				cm.CreateMap<Order, OrderDto>();
				cm.CreateMap<Product, ProductDto>();
				cm.CreateMap<ProductDto, Product>();
				cm.CreateMap<CategoryEnum, CategoryEnumDto>();
				cm.CreateMap<CategoryEnumDto, CategoryEnum>();
				cm.CreateMap<OrderEnum, OrderEnumDto>();
				cm.CreateMap<OrderEnumDto, OrderEnum>();
			});


			services.AddTransient<IUserRepository>((c) => new UserRepository(Configuration.GetConnectionString("MongoDatabaseConnection")));
			services.AddTransient<IProductRepository>((c) => new ProductRepository(Configuration.GetConnectionString("MongoDatabaseConnection")));
			services.AddTransient<IOrderRepository>((c) => new OrderRepository(Configuration.GetConnectionString("MongoDatabaseConnection")));

			services.AddTransient<IUserService, CherrieCouture.Domain.Service.UserService>();
			services.AddTransient<IProductService ,CherrieCouture.Domain.Service.ProductService>();
			services.AddTransient<IOrderService ,CherrieCouture.Domain.Service.OrderService>();
			services.AddTransient<ILoginService ,CherrieCouture.Domain.Service.LoginService>();

			services.AddSwaggerGen(c =>
			{
				
				c.SwaggerDoc("v2", new Info { Title = "CherrieCouture", Version = "v2" });
			});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

			app.UseSwagger();

			app.UseSwaggerUI(x =>
			{
				x.SwaggerEndpoint("../swagger/v2/swagger.json", "CherrieCouture");
			});

		}
    }
}
