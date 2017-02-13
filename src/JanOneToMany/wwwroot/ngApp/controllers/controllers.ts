namespace JanOneToMany.Controllers {

    export class HomeController {
        public categories;

        constructor(private $http: ng.IHttpService) {
            this.$http.get(`/api/categories`).then((response) => {
                this.categories = response.data;
            })
        }
    }



    export class AboutController {
        public category;
        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService) {
            let catId = this.$stateParams[`id`];

            this.$http.get(`/api/categories/` + catId).then((response) => {
                this.category = response.data;
            })

        }
    }

    export class AddCategoryController {
        public category;

        public addCategory() {
            this.$http.post(`/api/categories`, this.category).then((response) => {
                this.$state.go(`home`);
            })
        }

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {

        }
    }

    export class AddMovieController {
        public movie;
        public categories;

        public addMovie() {
            this.$http.post(`/api/movies`, this.movie).then((response) => {
                this.$state.go(`home`);
            })
        };

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get(`/api/categories`).then((response) => {
                this.categories = response.data;
            })
        }
    }

}


