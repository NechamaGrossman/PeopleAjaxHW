$(() => {
    function loadPeople() {
        $("#people-table tbody td").remove();
        $.get('/Home/People',
            ppl => {
                ppl.forEach(p => {
                    $("#people-table tbody").append(`
                        <tr>
                          <td>${p.firstName}</td>
                         <td>${p.lastName}</td>
                         <td>${p.age}</td>
                         <td><button class="btn btn btn-danger delete"  data-id-delete="${p.id}" >delete</button></td>
                        <td><button class="btn btn btn-primary edit"  data-first-name="${p.firstName}" data-last-name="${p.lastName}" data-age="${p.age}" data-id="${p.id}" >Edit</button></td>
                        </tr>`);
                });
            });
    }
    loadPeople();
    $("#people-table").on('click', '.edit', function () {
        const button = $(this);
        $("#FirstName-edit").val(button.data('first-name'));
        $("#LastName-edit").val(button.data('last-name'));
        $("#Age-edit").val(button.data('age'));
        $("#Id-edit").val(button.data('id'));
        $("#my-modal").modal();
        $(".save-changes-edit").on('click', function () {
            const firstName = $("#FirstName-edit").val();
            const lastName = $("#LastName-edit").val();
            const age = $("#Age-edit").val();
            const id = $("#Id-edit").val();
            console.log(id);
            const person = {
                firstName: firstName,
                lastName: lastName,
                age: age,
                id: id
            };
            $.post(`Home/EditPerson`, person, function (p) {
                $("#my-modal").modal('hide');
                loadPeople();
            })
        })

    })
    $("#people-table").on('click', '.delete', function () {
        const btn = $(this);
        const id = btn.data('id-delete');
        $.post(`Home/DeletePerson`, { id }, function (p) {
            loadPeople();
        })
    })
})