(function() {
    $(function() {
        var _personService = abp.services.app.person;
        var _$modal = $('#PersonCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
            rules: {
                Name: "required",
                Email: "required"
            }
        });

        $('#RefreshButton').click(function () {
            refreshPersonList();
        });

        function refreshPersonList() {
            location.reload(true); //reload page to see new user!
        }

        $('.delete-person').click(function () {
            var personId = $(this).attr("data-person-id");
            var personName = $(this).attr('data-person-name');

            deleteUser(personId, personName);
        });

        function deleteUser(personId, personName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'PhoneBook'), personName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _personService.deletePerson({
                            id: personId
                        }).done(function () {
                            refreshPersonList();
                        });
                    }
                }
            );
        }

        $('.edit-person').click(function (e) {
            var personId = $(this).attr("data-person-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Persons/EditPersonModal?personId=' + personId,
                type: 'POST',
                contentType: 'application/html',
                //Override abp.ajax default dataType https://github.com/aspnetboilerplate/module-zero-core-template/pull/474
                dataType: 'html',
                success: function (content) {
                    //console.log(content);
                    $('#PersonEditModal div.modal-content').html(content);
                },
                error: function (e) {
                }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var person = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            //person.roleNames = [];
            //var _$roleCheckboxes = $("input[name='role']:checked");
            //if (_$roleCheckboxes) {
            //    for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
            //        var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
            //        user.roleNames.push(_$roleCheckbox.val());
            //    }
            //}
            
            person.PhoneNumbers = [];

            var phoneNumber = {};
            phoneNumber.Number = person.Number;

            person.PhoneNumbers.push(phoneNumber);
            console.log(person);

            abp.ui.setBusy(_$modal);
            console.log(_personService);
            _personService.createOrUpdatePerson(person).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new user!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
    });
})();