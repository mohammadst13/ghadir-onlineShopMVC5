/// <reference path="../scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../scripts/kendoui/kendo.all.d.ts" />


module KendoGrid {
    export class ViewModel extends kendo.data.ObservableObject {

        public productsDataSource: kendo.data.DataSource;

        //Model = new kendo.data.Model({
        //    "ProductID": { type: "number" },
        //    "Title": { type: "string" },
        //    "Count": { type: "number" },
        //    "Price": { type: "number" },
        //    "Sum": { type: "number" },
        //    "ImageName": { type: "string" }
        //});

        constructor() {
            super();
            super.init(this);
            this.productsDataSource = new kendo.data.DataSource({
                transport: {
                    read: {
                        url: "ShopCart/GetProducts",
                        dataType: "json",
                        contentType: 'application/json; charset=utf-8',
                        type: 'GET'
                    },
                    parameterMap: function (options) {
                        return kendo.stringify(options);
                    }
                },
                schema: {
                    //model: this.Model
                    //"ProductID": { type: "number" },
                    //"Title": { type: "string" },
                    //"Count": { type: "number" },
                    //"Price": { type: "number" },
                    //"Sum": { type: "number" },
                    //"ImageName": { type: "string" }
                },
                error: function (e) {
                    alert(e.errorThrown);
                },
                pageSize: 10,
                sort: { field: "Id", dir: "desc" },
                serverPaging: true,
                serverFiltering: true,
                serverSorting: true
            });

            $("#grid").kendoGrid({
                dataSource: this.productsDataSource,
                autoBind: true,
                scrollable: false,
                pageable: true,
                sortable: true,
                filterable: true,
                reorderable: true,
                columnMenu: true,
                columns: [
                    { field: "ProductID", title: "شماره", width: "50px" },
                    { field: "Title", title: "نام محصول", width: "150px" },
                    { field: "Count", title: "تعداد" },
                    { field: "Price", title: "قیمت واحد", format: "{0:c}" },
                    { field: "Sum", title: "قیمت کل", format: "{0:c}" },
                    { field: "ImageName", title: "نام عکس", template: '<img class="thumbnail" style="max-width: 120px" src="/ProductImages/#=ImageName#" />' }
                ]
            });
        }

    }
}

$(function () {
    var viewModel = new KendoGrid.ViewModel();

    kendo.bind($("#grid"), viewModel);
});
