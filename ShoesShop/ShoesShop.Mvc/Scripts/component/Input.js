var InputComponent = function (params) {
    var self = this;
    self.isEditting = ko.observable(params.isEditting || true);
    self.name = params.name;
};
var elemInstance = document.getElementById('input-component');



ko.components.register('input-component', {
    viewModel: InputComponent,
    template: { element: elemInstance }
    
});