const div=document.querySelector('#root').textContent="Jestem divem!"
const personSelect = document.querySelector('#personSelect');
const selectedPersonElement = document.querySelector('#selectedPerson');

personSelect.addEventListener('change', () => {
    selectedPersonElement.textContent = personSelect.value;
});