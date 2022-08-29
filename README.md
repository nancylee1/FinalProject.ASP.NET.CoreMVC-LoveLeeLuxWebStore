<h2>What is LoveLeeLux?</h2>

My Final Project - LoveLeeLux Fashion Store, is a project only (not for real use) consignment store for Administrator use to manage their website. LoveLeeLux sells high end luxury accessories from different designers. The website uses the Microsoft.NET 6.0 framework that includes Dapper, MySQL database, and Razor Syntax using C#, JavaScript, HTML, CSS, Bootstrap, and Toastr to view Products in my Inventory, create, update, and delete them - working synchronously 
with MySQL database.

<h2>What coding languages are used?</h2>

I have integrated HTML, CSS, C#, and JavsScript as its main languages and also integrated ToastrJS and Boostrap as well. 

<h1> C# </h1>

C# is the main coding language used to communicate with the database and user. When the code is requested, it will pull and show information from the database for the 
user to see (using HTML), and will also let them push information back into the database (if they need to create/delete a product). The MySQL database is remote and the coding works
to specifically find and update the database over the internet (or locally).
C# also is the logic behind the page. You can create a product and upload a photo as well to the new product and the logic automatically assigns the product a new Product ID and files it in the right category.
Since the page is a web application, I was able to create if statements, selection statements, and loops, within the web page to allow specific commands to show when criteria is met. 

<h1> HTML & CSS </h1>

HTML provides the structure of the page, alongside CSS to compile the visual and aural layout. HTML pulled in my C# coding in the backend to communicate it to the frontend. 
I also integrated Bootstrap 5 as a framework to allow modern UI designs such as buttons, icons, modals, etc. Boostrap was also used for the cards on the products page to enhance user interaction 
with a clean and precise layout for the shopping view.

<h1> JavaScript </h1>

JavaScript was applied for the carousel layouts in the home and view products pages to recommend user an array of items based on their shopping preferences. 
Since I am still building out the Shopping Cart and Account User Logins, I cleverly used Toastr to provide the user pop-ups and animation. In order to successfully apply 
JS to the application, I added the appsettings.Json file to incorporate a Connection String to the database.

![Final Project - Home Page](https://user-images.githubusercontent.com/107009879/187266205-8e8a286d-2203-45a3-911f-81f219df7ced.png)
![Final Project - Home Page2](https://user-images.githubusercontent.com/107009879/187266531-fac104d3-7834-4852-b4c2-1956354b89ac.png)
![Final Project - Products Page](https://user-images.githubusercontent.com/107009879/187266704-32d1e255-165e-459d-9896-e16d8c8f6a94.png)
