/// <reference path="_references.js" />

var isoCultureInfo = {
    LanguageCultureName : ko.observable("")
};

var viewModel = {
    dataList: ko.observableArray([]),
    formattedString: ko.observable("Test"),
    selectedCulture: ko.observable(isoCultureInfo)
};

$(document).ready(function () {
    $.ajax("/CultureInfo/List",
        {
            type: "GET",
            contentType: "text/json"
        }).done(function (data) {
            viewModel.dataList = ko.mapping.fromJS(data);
            ko.applyBindings(viewModel);

            viewModel.selectedCulture.subscribe(function(newValue){
                if (newValue.LanguageCultureName() != '') {
                    var data = { "id": newValue.LanguageCultureName() };
                    $.ajax("/CultureInfo/FormattedText",
                        {
                            type: "POST",
                            contentType: "application/json",
                            data: JSON.stringify(data)
                        }).done(function (data) {
                            viewModel.formattedString(data.formattedCurrency);
                        }).error(function (args) {
                            alert("fcku");
                        });;
                };
            });
        }).error(function () {

        });
});
