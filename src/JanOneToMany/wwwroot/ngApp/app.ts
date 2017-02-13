namespace JanOneToMany {

    angular.module('JanOneToMany', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: JanOneToMany.Controllers.HomeController, 
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about/:id',
                templateUrl: '/ngApp/views/about.html',
                controller: JanOneToMany.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state(`addCategory`, {
                url: `/addCategory`, 
                templateUrl: `/ngApp/views/addCategory.html`, //<-- NOT YET CREATED!
                controller: JanOneToMany.Controllers.AddCategoryController,  
                controllerAs: `controller`
            })
            .state(`addMovie`, {
                url: `/addMovie`,
                templateUrl: `/ngApp/views/addMovie.html`,
                controller: JanOneToMany.Controllers.AddMovieController,
                controllerAs: `controller`
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    

}
