<template>
  <aside class="profile-nav alt">
    <section class="card">
      <div class="card-header user-header alt bg-dark">
        <div class="media">
          <a href="#">
            <img class="align-self-center rounded-circle mr-3" src="../../images/admin.jpg" />
          </a>
          <div class="media-body">
            <h2 class="text-light display-6">{{this.$store.state.app.login.name}}</h2>
            <p>{{this.$store.state.app.login.email}}</p>
          </div>
        </div>
      </div>
      <div class="card-body">
        <div class="row">
          <FormUP
            cols="col-4"
            id="PasswActual"
            label2="Senha Atual:"
            typeField="password"
            :vModel="cadastro.UserPass"
            :form="cadastro"
          ></FormUP>
          <FormUP
            cols="col-4"
            id="Senha"
            label2="Nova Senha:"
            typeField="password"
            :vModel="cadastro.UserPassNew"
            :form="cadastro"
          ></FormUP>
          <div class="col" style="padding-top:28px;">
            <button type="button" class="btn btn-primary m-b-10" @click.prevent="SavePassword()">
              <i class="fa fa-save"></i> Alterar Senha
            </button>
          </div>
        </div>
      </div>
    </section>
  </aside>
</template>
<script>
import FormUP from "../../components/formup/";
import { GetRest, PostRest } from "../../api/Generic";

export default {
  props: ["UserID"],
  components: {
    FormUP
  },
  data() {
    return {
      cadastro: {
        attemptSubmit: false,
        Id: this.$props.UserID,
        UserPass: new this.$InputUP(),
        UserPassNew: new this.$InputUP()
      },
      UserInfo: null
    };
  },
  mounted() {
    this.LoadObject();
  },
  methods: {
    async LoadObject() {
      let response = await GetRest("Person/GetProfile", this);
      if (response.data.Status == 200) {
        this.UserInfo = response.data.Data;
      }
    },
    async SavePassword() {
        this.cadastro.attemptSubmit = true;
      if (
        !this.ValidRequired([this.cadastro.UserPass, this.cadastro.UserPassNew])
      ) {
        return;
      }

      let response = await PostRest(
        {
          UserPass: this.cadastro.UserPass.value,
          UserPassNew: this.cadastro.UserPassNew.value
        },
        "Person/UpdatePassword",
        this
      );
      if (response.data.Status == 200) {
        this.cadastro.UserPass.value = "";
        this.cadastro.UserPass.status = null;
        this.cadastro.UserPassNew.value = "";
        this.cadastro.UserPassNew.status = null;
        this.$toast.open({
          message: "Senha Alterada com sucesso",
          type: "success"
        });
      }
    },
    ValidRequired: function(items) {
      let oneFalse = true;
      items.forEach(element => {
        if (
          (element.status == false || element.status == null) &&
          element.required
        ) {
          if (element.value != null && element.value != "")
            element.ChangeStatus(true);
          else element.ChangeStatus(false);

          oneFalse = false;
        }
      });

      return oneFalse;
    }
  }
};
</script>