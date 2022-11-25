<template>
  <q-page padding>
    <div class="text-h3 row">Memória Virtual</div>
    <br />
    <div class="row">
      <q-card class="col-12">
        <q-card-section>
          <div class="text-h6">Porcentagem de Uso:</div>
          <div class="row">
            <q-linear-progress size="25px" :value="porcentagemMemoria" color="blue">
              <div class="absolute-full flex flex-center">
                <q-badge color="white" text-color="blue" :label="obterPorcentagem" />
              </div>
            </q-linear-progress>
          </div>
        </q-card-section>
      </q-card>
    </div>
    <br />
    <div class="row justify-between">
      <q-card class="col-5">
        <q-card-section>
          <div class="text-h6">Tamanho:</div>
          <div class="row justify-center">
            <p class="text-h3">{{ tamanho }} KB</p>
          </div>
        </q-card-section>
      </q-card>
      <q-card class="col-5">
        <q-card-section>
          <div class="text-h6">Páginas Usadas:</div>
          <div class="row justify-center">
            <p class="text-h3"> {{paginasUsadas}} </p>
          </div>
        </q-card-section>
      </q-card>
    </div>
    <br />
    <div class="row justify-between">
      <q-card class="col-5">
        <q-card-section>
          <div class="text-h6">Páginas Totais:</div>
          <div class="row justify-center">
            <p class="text-h3"> {{totalPaginas}} </p>
          </div>
        </q-card-section>
      </q-card>
      <q-card class="col-5">
        <q-card-section>
          <div class="text-h6">Páginas Livres:</div>
          <div class="row justify-center">
            <p class="text-h3"> {{paginasLivres}} </p>
          </div>
        </q-card-section>
      </q-card>
    </div>
    <br/>
    <div class="row">
      <q-table
      title="Páginas"
      style="width:100%"
      :rows="rows"
      :columns="columns"
      row-key="identificador"
    />
    </div>
  </q-page>
</template>

<style lang="sass" scoped>
.text
</style>

<script>
import axios from 'axios';
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'PageMemoriaVirtual',
  beforeMount() {
    axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
    axios.defaults.headers.post['Content-Type'] ='application/x-www-form-urlencoded';
    axios
      .get('https://localhost:44306/api/MemoriaVirtual')
      .then(response => {
        this.rows = response.data.retorno.paginas.filter(p => p != null);
        this.tamanho = response.data.retorno.tamanho / 1000;
        this.paginasUsadas = response.data.retorno.paginasUsadas;
        this.totalPaginas = response.data.retorno.quantidadePaginas;
        this.paginasLivres = this.totalPaginas - this.paginasUsadas;
        this.porcentagemMemoria = this.paginasUsadas / this.totalPaginas;
      })
  },
  data() {
    return {
      info: "",
      paginasUsadas: 0,
      tamanho: 0,
      totalPaginas: 0,
      paginasLivres: 0,
      porcentagemMemoria: 0,
      columns: [
        {name: 'identificador', label: 'Identificador Página', field: 'identificador', sortable: true, align: 'left'},
        {name: 'conteudo', label: 'Conteúdo', field: 'conteudo', sortable: true, align: 'left'},
        {name: 'identificadorProcesso', label: 'Processo', field: 'identificadorProcesso', sortable: true, format: (val, row) => `Processo ${val}`, align: 'left'},
        {name: 'vezesAcessada', label: 'Vezes Acessada', field: 'vezesAcessada', sortable: true, align: 'left'},
      ],
      rows: []
    };
  },
  computed: {
    obterPorcentagem() {
      return (this.porcentagemMemoria * 100).toFixed(2).concat('%');
    }
  }
});
</script>
