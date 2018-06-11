function deleteByEmail() {
    let input = document.getElementsByName('email')[0].value;

    let emails = document.querySelectorAll('#customers tr td:last-child');

    let deleted = false;

    for (let email of emails) {
        if(email.textContent === input){
            let row = email.parentNode; // parentNode is the tr of the current td
            row.parentNode.removeChild(row); // parentNode of tr is tbody, so from there we remove the row we want
            deleted = true;
            break;
        }
    }

    if(deleted){
        document.getElementById('result').textContent = 'Deleted.';
    } else {
        document.getElementById('result').textContent = 'Not found.';
    }
}