import axios from 'axios';

const BASE_URL = 'http://207.244.243.219';
const USERNAME = 'admin';
const PASSWORD = 'admin123';

// FUNÇÃO QUE GERA TOKEN DE AUTENTICAÇÃO
async function getToken() {
  let token = '';
  await axios
    .post(`${BASE_URL}/index.php/rest/V1/integration/admin/token`, {
      username: USERNAME,
      password: PASSWORD,
    })
    .then(response => (token = response.data))
    .catch(error => console.log(error));

  return token;
}

function deleteProducts(token, productsList) {
  productsList.forEach(async product => {
    await axios
      .delete(`${BASE_URL}/index.php/rest/V1/products/${product}`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      })
      .then(response => {
        console.log(response);
      })
      .catch(error => {
        console.log(error);
      });
  });
}

const token = getToken();

// LISTA DE SKUs A SER DELETADO
const productsList = ['produto1', 'produto2', 'produto3', 'produto4', 'produto5', 'produto6'];

// CHAMA FUNÇÃO QUE DELETA OS PRODUTOS DA LISTA ACIMA
deleteProducts(token, productsList);
