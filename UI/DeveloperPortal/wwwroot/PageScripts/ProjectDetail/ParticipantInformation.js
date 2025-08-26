var IsLoadParticipantTab=false;
var ParticipantInformation=
{   
    Init:function () 
    {
    },
    LoadParticipants:function()
    {
        if(IsLoadParticipantTab==false)
        {
            if ($.fn.DataTable.isDataTable('#dtParticipants')) {
                $('#dtParticipants').DataTable().destroy();
            }
            var url= 'ProjectDetail/ProjectParticipants?projectId='+ProjectId+'&caseId='+Id;
            AjaxCommunication.CreateRequest(this.window, "GET", url, "", null,
                function (result) {
                   ParticipantInformation.LoadParticipantDataTable(result);
                }, null, true, null, false);
        
            IsLoadParticipantTab=true;
        }
    },
    LoadParticipantDataTable:function(result)
    {
       var columns = 
        [
            { data: 'contactName', title: "Name" },
            { data: 'email', title: "Email" },
            { data: 'phone', title: "Phone" },
            { data: 'fullAddress', title: "Full Address" },
            { data: 'contactType', title: "Type" },
            { data: 'source', title: "Source" },
            { data: 'status', title: "Status" },
            {
                data: null, title: "Actions" ,
                orderable: false,searchable: false,
                render: function (data, type, row) {
                return '<button role="button" class="editbtn btn k-button k-button-icontext k-grid-edit" title="Edit"  data-id="'+data.contactId+'"><i class="fas fa-pen editcontent"></i></button>&nbsp;'
                +'<button role="button" class="deletebtn btn k-button k-button-icontext k-grid-Delete" title="Delete" data-id="'+data.contactId+'"><i class="fas fa-trash-alt deletecontent"></i></button>';
                }
            }
        ];
                
        var dtParticipantsTable = $('#dtParticipants').dataTable({
            data:result,
            "columns": columns,
            processing: true,
            pageLength: 10,
            "paging": true,
            "searching": true,
            "ordering": false
        });
         $('#dtParticipants tbody').on('click', '.deletebtn', function () {
            const id = $(this).data('id');
          });
          $('#dtParticipants tbody').on('click', '.editbtn', function () {
            const id = $(this).data('id');
            
          });
    }
}