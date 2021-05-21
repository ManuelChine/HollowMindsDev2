# il container nasce dall'immagine node versione 14
FROM node:15

# directory un cui opera il container (dir di lavoro sul container)
WORKDIR /myapp

# copia il file dentro alla WORKDIR  ( il . = WORKDIR )
COPY package.json .

#esegui il comando npm install
RUN npm install

# copia tutti ciò che sta nella dir corrente (primo punto) nella WORKDIR (secondo punto)
COPY . .

EXPOSE 8082

# esegui il comando " node nodeapp.js"
CMD ["node", "increment.js"]
