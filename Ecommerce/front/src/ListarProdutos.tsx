//Componente

import { useEffect } from "react";

// - Precisa ser uma função
// - Precisa retornar apenas um elemento HTML pai
// Exportar o componente
function ListarProdutos(){

    // Realiza operações ao carregar o componente
    useEffect(() => {
        console.log("O componente foi carregado");
        buscarProdutosAPI();
        

    }, []);

    async function buscarProdutosAPI(){

        try {
        
            const resposta = await fetch("http://localhost:5089/api/produto/listar");

            console.log(resposta);

            if(!resposta.ok){
                throw new Error("Erro na requisição: " + resposta.statusText);
            }

            const dados = await resposta.json();
            console.log(dados);

            
        } catch (error) {
            console.log("Erro na requisição: " + error);
        }

        
    }

    return(
        <div id="listar_produtos">
            <h1> Listar Produtos </h1>
    
        </div>
);

}

export default ListarProdutos;