import { useEffect, useState } from "react";
import Produto from "../../../models/Produto";

//Componente
// - Composto por HTML, CSS e JS ou TS

// Regras para um componente
// - Precisa ser uma função
// - Precisa retornar apenas um elemento HTML pai
// Exportar o componente



function ListarProdutos(){

    //Estados - Variáveis
    const [produtos, setProdutos] = useState<Produto[]>([]);

    // Realiza operações ao carregar o componente
    useEffect(() => {
        console.log("O componente foi carregado");
        buscarProdutosAPI();
    }, []);

    async function buscarProdutosAPI(){
        try {
        
            const resposta = await fetch("http://localhost:5089/api/produto/listar");
            //console.log(resposta);

            if(!resposta.ok){
                throw new Error("Erro na requisição: " + resposta.statusText);
            }

            const dados = await resposta.json();
            setProdutos(dados);

            
        } catch (error) {
            console.log("Erro na requisição: " + error);
        } 
    }

    
    // O return é a parte visual do componente
    return(
        <div id="listar_produtos">
            <h1> Listar Produtos </h1>
            <table>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Nome</th>
                        <th>Descrição</th>
                        <th>Quantidade</th>
                        <th>Preço</th>
                        <th>CriadoEm</th>
                    </tr>
                </thead>
                <tbody>
                    {produtos.map((produto) =>
                    <tr>
                        <td>{produto.id}</td>
                        <td>{produto.nome}</td>
                        <td>{produto.descricao}</td>
                        <td>{produto.quantidade}</td>
                        <td>{produto.preco}</td>
                        <td>{produto.criadoEm}</td>
                    </tr>
                    
                
                    )}
                </tbody>
            </table>
            <ul>
                
            </ul>
        </div>
);

}

export default ListarProdutos;