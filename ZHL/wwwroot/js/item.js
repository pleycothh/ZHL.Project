﻿// keep reference to the row we are editing
let lastSender = undefined;


function deleteItem(sender, onFilter) {
    // Called like: openDialog(this), so we get a reference to the table row that called this function
    lastSender = sender;

    console.log("Delete Item: " + sender + type);

    let tr = lastSender;

    // server provides this for each row and hides it,
    // here we use the provided hash to uniquely identify this row
    let hash = tr.querySelector('.hash').textContent;
    let newNote = popup.querySelector('.notes').value;

    const cacheName = "tempId";
    
    //const urlParams = new URLSearchParams(window.location.search);
    //const cacheName = urlParams.get('CacheName');

    //tr.querySelector('.notes').textContent = newNote;

    if (!onFilter) {

        fetch(`/api/deleteItem/${cacheId}/${hashId}/`);
    }
    if (onFilter) {

        fetch(`/api/deleteFilter/${cacheId}/${hashId}/`);
    }
    

    lastSender = undefined;
}