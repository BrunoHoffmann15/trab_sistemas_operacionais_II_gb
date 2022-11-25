<template>
  <q-page padding>
    <div class="row">
      <q-table
      title="Processos"
      style="width:100%"
      :rows="rows"
      :columns="columns"
      selection="single"
      v-model:selected="selected"
      row-key="identificador"
    />
    </div>
    <br/>
    <div class="row">
      <q-btn color="primary" label="Adicionar" v-on:click="adicionarNovo"/>
      <q-btn id="historico" text-color="black" color="white" label="Ver Histórico" :disabled="!selected[0]"  v-on:click="verHistorico"/>
    </div>
    <q-dialog
      v-model="showDialog"
    >
      <q-card style="width: 700px; max-width: 80vw;">
        <q-card-section>
          <div class="text-h6">Medium</div>
        </q-card-section>

        <q-card-section class="q-pt-none">
          Click/Tap on the backdrop.
        </q-card-section>

        <q-card-actions align="right" class="bg-white text-teal">
          <q-btn flat label="OK" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </q-page>

  {{selected}}
</template>

<style>
#historico {
  margin-left: 10px;
}
</style>

<script>
import axios from 'axios';
import { defineComponent } from 'vue';
import { Dialog, Notify } from 'quasar';
import { useQuasar } from 'quasar'

export default defineComponent({
  name: 'PageProcesso',
  data () {
    return {
      rows: [],
      showDialog: false,
      selected: [],
      columns: [
        {name: 'identificador', label: 'Identificador Página', field: 'identificador', sortable: true, align: 'left'},
        {name: 'quantidadePaginas', label: 'Quantidade Páginas', field: 'quantidadePaginas', sortable: true, align: 'left'},
        {name: 'tamanho', label: 'Tamanho', field: 'tamanho', sortable: true, format: (val, row) => `${val} bytes`, align: 'left'}
      ],
    }
  },
  beforeMount() {
    axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';
    axios.defaults.headers.post['Content-Type'] ='application/x-www-form-urlencoded';
    axios
      .get('https://localhost:44306/api/Processo')
      .then(response => {
        this.rows = response.data.retorno.filter(p => p != null);
        this.tamanho = response.data.retorno.tamanho / 1000;
        this.paginasUsadas = response.data.retorno.paginasUsadas;
        this.totalPaginas = response.data.retorno.quantidadePaginas;
        this.paginasLivres = this.totalPaginas - this.paginasUsadas;
        this.porcentagemMemoria = this.paginasUsadas / this.totalPaginas;
      })
  },
  methods: {
    verHistorico() {
      this.showDialog = true;
    },

    adicionarNovo() {
      Dialog.create({
        title: 'Adicionar Processo',
        message: 'Qual o tamanho do processo em bytes?',
        prompt: {
          model: '',
          type: 'number' // optional
        },
        cancel: true,
        persistent: true
      }).onOk(data => {
        axios
        .post('https://localhost:44306/api/Processo', {
          tamanho: data
        }).then(response => {
          if (response.data.PossuiErro) {
            Notify.create({
              type: 'negative',
              message: response.data.MensagemErro
            });
          } else {
            Notify.create({
              type: 'positive',
              message: 'Processo criado com sucesso.'
            });
          }
        });
      }).onCancel(() => {

      }).onDismiss(() => {

      });
    },
  },
  setup () {
    const $q = useQuasar();
  }
});
</script>
