# contact-app
<h1>CRUD operation using Angular 5, Asp.Net Core 2.0 Web API, Entity Framework Core 2.0 Code First Fluent Style<h1>

<h2>Back-end Frameworks - Packages - Patterns - Features used: <h2>
<ul>
<li>ASP.NET Core 2.0 </li>
<li>ASP.NET Core Web API 2 </li>
<li>Entity Framework Core 2.0 </li>
<li>Entity Framework Migrations - Code First Fluent API</li>
<li>Repository Pattern</li>
<li>Generic Repository</li>
<li>Unit of Work pattern</li>
<li>.Net Core 2.0 built in Dependency Injection</li>
<li>FluentValidation</li>
<li>Automapper</li>
<li>Global Exception Handler</li>
<li>CORS</li>
</ul>

<h3>Installation Instructions for back-end project:</h3>
<ol>
<li>Open the solution in VS 2017</li>
<li>Modify the connection string in <i>appsettings.Development.json</i> to reflect your database environment</li>
<li>Build and run the ContactApp.API application, it will create DB with sample data.
  <li>Navigate to <i>http://localhost:5000/api/customers</i>, it should return some sample data.(Your port number may be different).
</ol>

<h2>Front-end Frameworks - Packages - Patterns - Features used:<h2> 
<ul>
<li>Angular 5 </li>
<li>Angular CLI </li>
<li>Webpack</li>
<li>font-awesome</li>
<li>Bootstrap</li>

<h3>Installation Instructions:</h3>
<ol>
<li>Open the ContactApp.SPA application in Visual Studio Code</li>
<li>Navigate to project root directory & run command from command shell: <b> npm install </b>
<li>Open <i>src/app/shared/utils/config.service.ts<i> file and set your back-end API url.
<li>Start Ng Live development server by typing command <b>ng serve -o </b> from ContactApp.SPA root directory.
<li>It will build & run ContactApp.SPA application & display home page.
<li>Navigate to various links like Customers and click on each customer to get that customer details & his enquiries.
</ol>
  
  
