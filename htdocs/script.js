const createVegetable = (vegetable) => {
    axios.post('https://localhost:44317/Vegetables', vegetable)
        .then(response => {
            const addedVegetable = response.data;
            console.log(`POST: vegetable is added`, addedVegetable);
        })
        .catch(error => console.error(error));
};

const form = document.querySelector('form');

const formEvent = form.addEventListener('submit', event => {
    event.preventDefault();

    const vid = document.querySelector('vid').value;
    const vname = document.querySelector('vname').value;

    const vegetable = { vid, vname };
    createVegetable(vegetable);
});

