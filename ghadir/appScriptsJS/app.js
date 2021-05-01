/// <reference path="../scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../scripts/kendoui/kendo.all.d.ts" />
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var KendoGrid;
(function (KendoGrid) {
    var ViewModel = /** @class */ (function (_super) {
        __extends(ViewModel, _super);
        //Model = new kendo.data.Model({
        //    "ProductID": { type: "number" },
        //    "Title": { type: "string" },
        //    "Count": { type: "number" },
        //    "Price": { type: "number" },
        //    "Sum": { type: "number" },
        //    "ImageName": { type: "string" }
        //});
        function ViewModel() {
            var _this = _super.call(this) || this;
            _super.prototype.init.call(_this, _this);
            _this.productsDataSource = new kendo.data.DataSource({
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
                dataSource: _this.productsDataSource,
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
            return _this;
        }
        return ViewModel;
    }(kendo.data.ObservableObject));
    KendoGrid.ViewModel = ViewModel;
})(KendoGrid || (KendoGrid = {}));
$(function () {
    var viewModel = new KendoGrid.ViewModel();
    kendo.bind($("#grid"), viewModel);
});
//# sourceMappingURL=app.js.map