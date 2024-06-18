# thunders-todo-test
Desenvolver um CRUD utilizando API REST, seguindo boas práticas de programação. O objeto do CRUD será uma lista de tarefas.

### Detalhes do Projeto
O candidato é livre para adicionar propriedades, regras de negócio, escolher o banco e o que achar necessário, não precisa se preocupar com a parte de segurança ou infra da aplicação, apenas o necessário para rodarmos e testarmos o CRUD. A única regra é que não deverá ser um CRUD complexo, não iremos avaliar a dificuldade do CRUD e sim o código e suas boas práticas.

### Como utilizar este projeto
Após clonar o repositório, navegue até o diretório `server`
```
cd .\server\
```

Este comando irá ler as configurações do arquivo `docker-compose.yml` e executar os serviços
```
docker-compose up --build
```

Verifique se a documentação da API está disponível com `Swagger`
```
http://localhost:5050/swagger/index.html
```

Navegue até o diretorio `client`
```
cd .\client\
```

Estes comandos irão criar a imagem e executar o conteiner da aplicação em Angular
```
docker build -t thunders-angular .
docker run -p 4200:4200 thunders-angular
```

Por fim, verfique se a aplicação está disponível
```
http://localhost:4200/
```
