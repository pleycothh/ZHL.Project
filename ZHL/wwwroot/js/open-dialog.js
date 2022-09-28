//// keep reference to the row we are editing
//let lastSender = undefined;
//
//
//function openDialog(sender) {
//    // Called like: openDialog(this), so we get a reference to the table row that called this function
//    lastSender = sender;
//
//    // capture info
//    let tr = sender;
//    let formName = tr.querySelector('.form-name').textContent;
//    let reportingTest = tr.querySelector('.reporting-test').textContent;
//    let desc = tr.querySelector('.desc').textContent;
//    let formLocation = tr.querySelector('.form-file-location').textContent;
//    let lineNumber = tr.querySelector('.line-number').textContent;
//
//    let oldNote = encodeURI(tr.querySelector('.notes').textContent);
//
//    // priority for review page
//    let priority = null;
//    if (tr.querySelector('.ignore-status') !== null) {
//        priority = tr.querySelector('.ignore-status').textContent;
//    }
//
//    // use captured info to populate the popup dialog
//    getDetails(formName, reportingTest, desc, lineNumber, formLocation, oldNote, priority);
//}
//
//// tries to get the table to realise we have updated the data
//function refreshTable() {
//    $('#table_id').DataTable().data.reload();
//}
//
//// using details gotten from openDialog(), populate the popup with the info and display it
//function getDetails(formName, reportingTest, desc, lineNumber, fileLocation, notes, priority) {
//    // reference to the popup
//    let popup = document.getElementById('popup-root');
//
//    popup.querySelector('.form-name').textContent = formName;
//    popup.querySelector('.reporting-test').textContent = reportingTest;
//    popup.querySelector('.desc').textContent = desc;
//    document.getElementById('popup-root').querySelector('.form-file-location').textContent = fileLocation;
//    if (document.getElementById('popup-root').querySelector('.form-file-location').textContent.includes('://')) {
//        document.getElementById('popup-root').querySelector('.form-file-location').href = '#';
//    } else {
//        document.getElementById('popup-root').querySelector('.form-file-location').href = '';
//    }
//    popup.querySelector('.line-number').textContent = lineNumber;
//
//    popup.querySelector('.notes').value = decodeURIComponent(notes);
//
//    // set priority for review page only
//    if (priority !== null) {
//        priorities = popup.querySelectorAll('.prio-picker-label');
//        priorities.forEach(x => {
//            if (priority.includes(x.innerText.trim())) {
//                x.firstElementChild.checked = true;
//            }
//        })
//    }
//    // browser compatibility check
//    if (typeof popup.showModal === 'function') {
//        popup.showModal();
//    } else {
//        alert('The <dialog> API is not supported by this browser');
//        console.log('ERROR: The <dialog> API is not supported by this browser');
//    }
//}
//
//// cancel button on popup
//function cancelModal() {
//    document.getElementById('popup-root').close();
//    lastSender = undefined;
//}
//
//function performSaveNotes() {
//    let tr = lastSender;
//    let popup = document.getElementById('popup-root');
//
//    // server provides this for each row and hides it,
//    // here we use the provided hash to uniquely identify this row
//    let hash = tr.querySelector('.hash').textContent;
//
//    let oldNote = tr.querySelector('.notes').textContent;
//    let newNote = popup.querySelector('.notes').value;
//
//    const urlParams = new URLSearchParams(window.location.search);
//    const cacheName = urlParams.get('CacheName');
//
//    if (oldNote !== '' && newNote === '') {
//        tr.querySelector('.notes').textContent = newNote;
//        fetch(`/api/ClearNote/${hash}/${cacheName}/`);
//    } else if (oldNote !== newNote) {
//        tr.querySelector('.notes').textContent = newNote;
//        const safeNote = encodeURIComponent(newNote);
//
//        if (!cacheName) {
//            throw 'Error: Cache was not able to be determined, note was not able to be set and will be lost!';
//        } else {
//            Promise.resolve(
//                fetch(`/api/SetNote/${hash}/${safeNote}/${cacheName}`).then((res) => {
//                    if (!res.ok) {
//                        console.error('unable to save note...');
//                    }
//                })
//            );
//        }
//    }
//}
//
//// save button on popup
//function saveModal() {
//
//    performSaveNotes();
//    performSaveNotes();
//
//    document.getElementById('popup-root').close();
//    lastSender = undefined;
//}
//
//function reviewModal() {
//
//    let tr = lastSender;
//    let popup = document.getElementById('popup-root');
//
//    let hash = tr.querySelector('.hash').textContent;
//    let desc = tr.querySelector('.desc').textContent;
//
//    const urlParams = new URLSearchParams(window.location.search);
//    const cacheName = urlParams.get('CacheName');
//
//    var selectedPriority = '';
//    for (var e of document.getElementsByClassName('priority-picker-item')) {
//        if (e.checked) {
//            // have to trim because the DOM contains newlines from formatting
//            // if e is the radio button itself, e.parent will be the pill around it (which contains the text like `Valid`)
//            selectedPriority = e.parentElement.textContent.trim();
//            break;
//        }
//    }
//
//    // used to make a string like '0 - Urgent', these must match the C# enum Priorities
//    var priorityToId = {
//        'Urgent': 0,
//        'High': 1,
//        'Medium': 2,
//        'Low': 3,
//        'Valid': 4,
//        'Invalid Test': 5
//    }
//
//    if (selectedPriority !== '' && cacheName !== '') {
//        // only adds to ignorelist with provided priority
//        Promise.resolve(
//
//            fetch(`/api/ignoreItem/${hash}/${cacheName}/${encodeURIComponent(desc)}/${selectedPriority}/`)
//                .then((res) => {
//                    console.log('ignore item');
//                    if (res.ok) {
//                        performSaveNotes();
//                        // on ignore page
//                        if (window.location.href.includes('Ignored')) {
//                            // Update priority here
//                            var statusRow = tr.querySelector('td.ignore-status');
//                            var prioString = `${priorityToId[selectedPriority]} - ${selectedPriority}`;
//                            statusRow.setAttribute('data-status', prioString);
//                            statusRow.innerHTML = prioString;
//
//                        } else {
//
//                            tr.style.display = 'none';
//                        }
//
//                        popup.close();
//                        lastSender = undefined;
//                    } else {
//                        console.error('unable to mark as processed...');
//                    }
//                })
//        );
//    }
//}
//
//// restore
//function restorable(sender) {
//    let tr = sender;
//
//    let hash = tr.querySelector('.hash').textContent;
//
//    const urlParams = new URLSearchParams(window.location.search);
//    const cacheName = urlParams.get('CacheName');
//
//    tr.style.display = 'none';
//    Promise.resolve(
//        fetch(`/api/restoreItem/${hash}/${cacheName}`)
//    );
//
//    lastSender = undefined;
//}