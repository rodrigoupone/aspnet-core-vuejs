<template>
  <div class="sufee-login d-flex">
    <div class="container d-flex justify-content-around">
      <div class="card">
        <div class="card-header">
          <h3>Monte seu pedido</h3>
        </div>
        <div class="card-body">
          <div class="row">
            <FormUP
              cols="col"
              id="sabor"
              label2="Sabor:"
              typeField="select"
              :vModel="cadastro.IdSabor"
              :form="cadastro"
              :options="Sabores"
            ></FormUP>
          </div>
          <div class="row">
            <FormUP
              cols="col"
              id="tamanho"
              label2="Tamanho:"
              typeField="select"
              :vModel="cadastro.IdTamanho"
              :form="cadastro"
              :options="Tamanhos"
            ></FormUP>
          </div>
          <div class="row">
            <FormUP
              cols="col"
              id="adicionais"
              label2="Adicionais:"
              typeField="checkbox"
              :vModel="cadastro.adicionais"
              placeholder="Escolha os adicionais"
              :form="cadastro"
              :options="Adicionais"
              :multiple="true"
            ></FormUP>
          </div>
          <div class="row">
            <div class="col btn-finaliza">
                <b-button variant="primary" v-if="Pedido" @click.prevent="ResetForm()">Novo Pedido</b-button>                
              <b-button variant="success" v-if="!Pedido" @click.prevent="ValidaForm()">Finalizar Pedido</b-button>
            </div>            
          </div>
        </div>
      </div>
      <div class="card">
        <div class="card-header">
          <h3>Resumo do pedido</h3>
        </div>
        <div class="card-body"  v-if="Pedido">
            <div class="row">
                <div class="col">
                    <p><strong>Sabor: </strong>{{Pedido.sabor}}</p>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <p><strong>Tamanho: </strong>{{Pedido.tamanho}}</p>
                </div>
            </div>            
            <div class="row">
                <div class="col">
                    <p><strong>Adicionais: </strong>{{Pedido.personalizacoes}}</p>
                </div>
            </div>           
            <div class="row">
                <div class="col">
                    <hr />
                </div>
            </div>                         
            <div class="row">
                <div class="col float-right">
                    <p><strong>Tempo de Preparo: </strong>{{Pedido.tempoTotal}} min<br>
                    <strong>Valor Total: </strong> R$ {{ Pedido.tempoTotal | currency}}</p>
                </div>
            </div>            
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import FormUP from "../../components/formup/";
import { GetRest, PostRest } from "../../api/Generic";

export default {
  name: "Pedido",
  components: {
    FormUP
  },
  data() {
    return {
      Tamanhos: [],
      Sabores: [],
      Adicionais: [],
      Pedido: null,
      cadastro: {
        attemptSubmit: false,
        IdSabor: new this.$InputUP(),
        IdTamanho: new this.$InputUP(),
        adicionais: new this.$InputUP(false, [])
      }
    };
  },
  mounted() {
    this.GetTamanhos();
    this.GetSabores();
    this.GetAdicionais();
  },
  methods: {
    ValidaForm: function() {
      this.cadastro.attemptSubmit = true;

      if (
        this.ValidRequired([this.cadastro.IdSabor, this.cadastro.IdTamanho])
      ) {
        this.onSubmit();
      }
    },
    ValidRequired: function(items) {
      let oneFalse = true;
      items.forEach(element => {
        if (
          (element.status == false || element.status == null) &&
          element.required
        ) {
          element.ChangeStatus(false);
          oneFalse = false;
        }
      });

      return oneFalse;
    },
    async onSubmit() {
      let data = {
        IdSabor: this.cadastro.IdSabor.value,
        IdTamanho: this.cadastro.IdTamanho.value,
        Adicionais: this.cadastro.adicionais.value
      };

      let response = await PostRest(data, "Pedido", this);

      if (response.status == 200) {
        this.Pedido = response.data;
        this.$swal.fire({
          title: "Sucesso",
          text: "Pedido realizado com sucesso.",
          icon: "success",
          showCancelButton: false,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "OK"
        });
      } else {
        this.$swal
          .fire({
            title: "Falha",
            text: "Ocorreu ume erro durante o seu cadastro tente novamente.",
            icon: "error",
            showCancelButton: false,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "OK"
          })
          .then(result => {
            if (result.value) {
              this.showModal = false;
            }
          });
      }
    },
    ResetForm :function(){
        this.cadastro.attemptSubmit= false;
        this.cadastro.IdSabor.value = null;
        this.cadastro.IdSabor.state = null;
        this.cadastro.IdTamanho.value = null;
        this.cadastro.IdTamanho.state = null;
        this.cadastro.adicionais.state = null;        
        this.cadastro.adicionais.value = [];     
        this.Pedido = null;           
    },
    async GetTamanhos() {
      let apiResponse = await GetRest("Tamanho", this);
      if (apiResponse.success) {
        apiResponse.data.forEach(item =>
          this.Tamanhos.push({
            text: item.nome,
            value: item.id
          })
        );
      }
    },
    async GetSabores() {
      let apiResponse = await GetRest("Sabor", this);
      if (apiResponse.success) {
        apiResponse.data.forEach(item =>
          this.Sabores.push({
            text: item.nome,
            value: item.id
          })
        );
      }
    },
    async GetAdicionais() {
      let apiResponse = await GetRest("Adicional", this);
      if (apiResponse.success) {
        apiResponse.data.forEach(item =>
          this.Adicionais.push({
            text: item.nome,
            value: item.id
          })
        );
      }
    }
  }
};
</script>
