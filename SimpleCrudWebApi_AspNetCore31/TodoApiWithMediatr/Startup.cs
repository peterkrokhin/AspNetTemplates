
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using AutoMapper;
using MediatR;
using FluentValidation.AspNetCore;

using TodoApiWithMediatr.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace TodoApiWithMediatr
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv => 
                { 
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>(); 
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false; 
                });;
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TodoList"));
            services.AddSwaggerGen(c => c.AddFluentValidationRules());
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
