# Portfolio - 2018

#### Developed by

- Simon Sinding
- Jonas Alslev Rasmussen

## Description
There are two project folders

### Joller - Backend
It's written in .NET, and it's a REST API.

It's rough around the edges, but it works.

It uses the [NancyFX](https://github.com/NancyFx/Nancy) framework, which is a lightweight framework for building HTTP based services
#### Joller dependensies.
- Mongodb >= 3.6
- DotNet core >= 2.0

### Milton - Frontend
The frontend is written in Javascript using the **aaawwwwwesome!** [Vue](https://github.com/vuejs/vue) framework and the even more **aaawwwwwesome** [Quasar](https://github.com/quasarframework/quasar) framework on top of that.

#### Milton dependencies.
- Node.js >= 8.9.0
- Npm

### Prerequsites
Make sure you have an instance of mongodb running, read more [here](https://docs.mongodb.com/tutorials/install-mongodb-on-windows/#run-mongodb-community-edition).

Once mongodb is running, you can proceed.

Make sure the dependencies of Milton is installed.
```bash
cd Milton
npm install
```

### Starting the project.
Start mongodb 
example command ``mongodb --dbpath /path/to/your/dbfile``
Then start Joller
```bash
cd Joller
dotnet bin/Debug/netcoreapp2.0/NancyTemplate.dll
```
Once Joller is up and running, then start Milton
```bash
cd Milton
npm run serve
```

**Done**

And as alllllwaaays.... Eeeeennnnnjoooy!
