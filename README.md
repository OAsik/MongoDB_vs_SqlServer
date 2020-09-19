A simple .net core API where you can perform basic CRUD operations both on MongoDB and SQL Server. You can check this repository to see the implementation of MongoDB driver to a .net core web app. API results simply return the amount of time spent on the same operation which is performed by different db providers.

This repository might be helpful to you too if your app is using different DB providers at the same time. Eventhough repository pattern is not necessary while working with EF core, I still use it in this solution as I have a MongoDB instance too. Apart from that, a factory pattern is established to distinguish between MongoDB and SQL Server repositories.

Last but not least, DI is used on business operation classes, DB settings and repository classes to make them loosely coupled and easy to test.
