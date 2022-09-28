// keep reference to the row we are editing
let lastSender = undefined;


function deleteItem(sender, onFilter) {
    // Called like: openDialog(this), so we get a reference to the table row that called this function
    lastSender = sender;

    console.log("Delete Item: " + sender + onFilter);

    let tr = lastSender;

    console.log("tr:" + tr)
    // server provides this for each row and hides it,
    // here we use the provided hash to uniquely identify this row
    let hash = tr.querySelector('.hash').textContent;

    console.log("hash:" + hash);
 //   let newNote = popup.querySelector('.notes').value;
 //
 //   const cacheName = "tempId";
 //   
 //   //const urlParams = new URLSearchParams(window.location.search);
 //   //const cacheName = urlParams.get('CacheName');
 //
 //   //tr.querySelector('.notes').textContent = newNote;
 //
     if (!onFilter) {

         console.log("item is:");
         fetch(`/api/deleteItem/${"tempId"}/${hash}/`);
     }
     if (onFilter) {
  
         console.log("filter is:");
         fetch(`/api/deleteFilter/${"tempId"}/${hash}/`);
     }
    

    lastSender = undefined;
}