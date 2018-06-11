function validate() {
    let email = document.getElementById('email');
    email.addEventListener('change', onChange);

    function onChange() {
        let regex = /^([\w\-.]+)@([a-z]+)(\.[a-z]+)+$/;

        if (!regex.test(this.value)) {
            this.className = 'error';
        } else {
            //this.removeAttribute('class');
            this.className = 'class';
        }

        // or
        // let match = regex.exec(this.value);
        // if(!match){
        //     this.className = 'error';
        // }
        // else{
        //     this.removeAttribute('class');
        // }
    }
}