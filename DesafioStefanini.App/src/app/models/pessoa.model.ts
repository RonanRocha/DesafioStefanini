import { Cidade } from "./cidade.model";

export interface Pessoa {
    id: number;
    nome: string;
    idade: number;
    cpf: string
    cidade: Cidade
}