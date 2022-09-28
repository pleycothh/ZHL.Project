// keep reference to the row we are editing
let lastSender = undefined;


function deleteItem(sender, onFilter) {
    // Called like: openDialog(this), so we get a reference to the table row that called this function
    lastSender = sender;

    let tr = lastSender;

    let hash = tr.querySelector('.hash').textContent;

     if (!onFilter) {

         console.log(hash + " - Item deleted!");
         Promise.resolve(
            fetch(`/api/deleteItem/${hash}/`)
         );
     }
     if (onFilter) {
  
         console.log( hash + " - Filter deleted!");
         Promise.resolve(
             fetch(`/api/deleteFilter/${hash}/`)
         );
     }
    tr.style.display = 'none';

    lastSender = undefined;
}