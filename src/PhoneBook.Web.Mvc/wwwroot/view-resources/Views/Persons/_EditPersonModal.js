(function ($) {
    var _personService = abp.services.app.person;
    var _$modal = $('#PersonEditModal');
    var _$form = $('form[name=PersonEditForm]');
    function save() {

        if (!_$form.valid()) {
            return;
        }

        var person = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
        person.PhoneNumbers = [];

        var phoneNumbers = $("input[name = 'EditNumber']");
        //console.log(phoneNumbers);
        if (phoneNumbers) {
            for (var i = 0; i < phoneNumbers.length; i++) {
                var phoneNumber = {};
                phoneNumber.Id = $(phoneNumbers[i]).attr("id");
                phoneNumber.Number = $(phoneNumbers[i]).val();
                person.PhoneNumbers.push(phoneNumber);
            }
            //for (var i = 0; i < phoneNumbers.length; i++) {

            //}
        }
        console.log(person);
        
        abp.ui.setBusy(_$form);
        _personService.createOrUpdatePerson(person).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited person!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);