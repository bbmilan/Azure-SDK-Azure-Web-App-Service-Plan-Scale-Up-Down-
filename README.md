# Azure SDK example (Azure Web App - Vertical Scaling process automation)
Imagine you are developing a web application that requires to provide users with the ability to upload and store files in Azure Blob Storage, authenticate users using Azure Active Directory (Azure AD), and perform real-time data processing using for example Azure Functions. On top of these, when certain conditions are met, you may be required to vertically auto-scale a web app service plan that is hosting some of your important APIs. And you may want to automate the vertical scaling process.

In this scenario, you can certainly use REST API endpoints to integrate with required Azure services. However, you may find that this approach is not the most efficient. For example, you may need to write a lot of code to handle authentication and authorization, handle retries and exceptions, handle a lot of serialization and deserialization of data, etc. 

That's where Azure SDKs come in handy. Azure SDKs are libraries that provide a higher-level abstraction for interacting with Azure services. The Azure SDKs abstract away the boilerplate code required to manage cloud-based Azure platform REST requests such as authentication, retries, logging etc. Azure SDKs are available for a variety of programming languages and platforms, including .NET, Java, JavaScript, Python, and Go.

In this example, I will focus on using Azure SDK for developing Azure serverless functions that Azure Monitor action groups will trigger to scale up and or down a web app service plan, when certain (load) conditions are met. Below is the architecture diagram of the solution.


![GitHub Logo](https://user-images.githubusercontent.com/56024878/273835122-afd39c00-fc8e-4b67-8058-957a5f6918b7.png)

Azure function 1 - perform scaling up of the web app service plan

Azure function 2 - perform scaling down of the web app service plan


## Usage

To run this code locally, you will need the following:

    .NET 6.0

    Azure Functions Core Tools version 4.x

    Visual Studio 2022 or Visual Studio Code


## Contributing

Guidelines for contributing to the project.
