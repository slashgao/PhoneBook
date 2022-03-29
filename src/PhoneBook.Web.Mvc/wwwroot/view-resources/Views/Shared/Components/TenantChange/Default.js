(function () {
    $('.tenant-change-component a')
        .click(function (e) {
            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Account/TenantChangeModal',
                type: 'POST',
                contentType: 'application/html',
                //Override abp.ajax default dataType https://github.com/aspnetboilerplate/module-zero-core-template/pull/474
                dataType: 'html',
                success: function (content) {
                    $('#TenantChangeModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });
})();
