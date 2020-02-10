<template>
  <div :class="cols">
     

    <b-form-group
      v-if="typeField === 'textMask'"
      :id="'input-group-'+id"
      :label-for="id"
      :description="description"
      :invalid-feedback="messageValidation"
      :state="state"
    >
      <template v-slot="label">
        <label :for="'input-'+id" class="d-block">
          {{label2}}
          <span class="text-danger" v-if="required">*</span>
        </label>
        <b-form-input

          :id="'input-' + id"
          v-model="vModel.value"
          typeField="text"
          :placeholder="placeholder"
          :state="state"
          v-mask="mask2"
          @change="validationInput(callback);"
        ></b-form-input>
      </template>
      <b-form-invalid-feedback v-if="messageValidation">{{messageValidation}}</b-form-invalid-feedback>
    </b-form-group>

         <b-form-group
      v-else-if="typeField == 'selectTwo'"
      :id="'input-group-'+id"
      :label-for="'select'+id"
      :description="description"
      :invalid-feedback="messageValidation"
      :state="state"
    >
      <template v-slot="label">
        <label :for="'input-'+id" class="d-block">
          {{label2}}
          <span class="text-danger" v-if="required">*</span>
        </label>
        <v-select 
        :id="'select-'+id"
        v-model="vModel.value" 
        @change="validationInput"
        :multiple="multiple"
        :options="options"
        @input="validationSelectTwo"
        ></v-select>
      </template>
      <b-form-invalid-feedback v-if="messageValidation">{{messageValidation}}</b-form-invalid-feedback>
    </b-form-group>


    <b-form-group
      v-else-if="((typeField === 'text' || typeField === 'password') && !mask)"
      :id="'input-group-'+id"
      :label-for="id"
      :description="description"
      :invalid-feedback="messageValidation"
      :state="state"
    >
      <template v-slot="label">
        <label :for="'input-'+id" class="col-form-label col-form-label-sm">
          {{label2}}
          <span class="text-danger" v-if="required">*</span>
        </label>
        <b-form-input
          size="sm"
          :id="'input-' + id"
          v-model="vModel.value"
          :type="typeField"
          :placeholder="placeholder"
          :state="state"
          @change="validationInput();"
        ></b-form-input>
      </template>
      <b-form-invalid-feedback v-if="messageValidation">{{messageValidation}}</b-form-invalid-feedback>
    </b-form-group>



    <b-form-group
      v-else-if="typeField === 'select'"
      :id="'input-group-'+id"
      :label-for="id"
      :description="description"
      :invalid-feedback="messageValidation"
      :state="state"
    >
      <template v-slot="label">
        <label :for="'input-'+id" class="d-block">
          {{label2}}
          <span class="text-danger" v-if="required">*</span>
        </label>

        <b-form-select
          :id="'input-' + id"
          v-model="vModel.value"
          :placeholder="placeholder"
          :state="state"
          :options="options"
          @change="validationInput();"
        ></b-form-select>
      </template>
      <b-form-invalid-feedback v-if="messageValidation">{{messageValidation}}</b-form-invalid-feedback>
    </b-form-group>



    
    <b-form-group
      v-else-if="typeField === 'radio'"
      :id="'input-group-'+id"
      :label-for="id"
      :description="description"
      :invalid-feedback="messageValidation"
      :state="state"
    
    >
      <template v-slot="label">
        <label :for="'input-'+id" class="d-block">
          {{label2}}
          <span class="text-danger" v-if="required">*</span>
        </label>

        <b-form-radio-group
          :id="'radio-group-' + id"
          v-model="vModel.value"
          :name="'radio-sub-' + id"
          :options="options"
        ></b-form-radio-group>
      </template>
      <b-form-invalid-feedback v-if="messageValidation">{{messageValidation}}</b-form-invalid-feedback>
    </b-form-group>

    
    <b-form-checkbox-group
      v-else-if="typeField === 'checkbox'"
      :id="'input-group-'+id"
      :label-for="id"
      :description="description"
      :invalid-feedback="messageValidation"
      :state="state"
    
    >
      <template v-slot="label">
        <label :for="'radio-checkbox-'+id" class="d-block">
          {{label2}}
          <span class="text-danger" v-if="required">*</span>
        </label>

        <b-form-checkbox-group
          :id="'radio-checkbox-' + id"
          v-model="vModel.value"
          :name="'radio-sub-' + id"
          :options="options"
           @input="validationCheckbox"
        ></b-form-checkbox-group>
      </template>
      <b-form-invalid-feedback v-if="messageValidation">{{messageValidation}}</b-form-invalid-feedback>
    </b-form-checkbox-group>
  </div>
</template>
<script>
import {mask} from 'vue-the-mask'

export default {
  directives: {mask},
  name: "FormUP",
  props: [
    "cols",
    "description",
    "id",
    "label2",
    "typeField",
    "vModel",
    "placeholder",
    "form",
    "errorMessage",
    "errorMessageValidation",
    "mask",
    "options",
    "validationType",
    "multiple", 
    'callback'
  ],
  data() {
    return {
      labelComp: this.$props.label,
      required: this.$props.vModel.required,
      mask2: this.$props.mask ? this.$props.mask : undefined,
      messageValidation: this.$props.errorMessageValidation,
      valType: this.$props.validationType,
      state: this.$props.vModel.status,
      model: this.$props.vModel
    };
  },
  computed: {
    errorMessageComputed: function() {
      return this.$props.errorMessage == null
        ? "Campo Requerido"
        : this.$props.errorMessage;
    }
  },
  watch: {
    state: function() {
      this.$props.vModel.status = this.state;
    },
    'vModel.status' : function(newVal){
        this.state = newVal;
        this.validationInput();
    },
    'form.attemptSubmit' : function(newVal){
        this.validationInput();
    }    
  },
  methods: {
    getState: function() {
      if (!this.$props.form.attemptSubmit) {
        this.$props.vModel.status = this.isNullOrEmpty(
          this.$props.vModel.value
        );
        return null;
      } else {
        if (!this.required) return null;
        else if (this.$props.vModel.value === undefined && this.required) {
          return false;
        } else {
          this.$props.vModel.status = this.isNullOrEmpty(this.$props.vModel.value) && this.required;
        }
      }
    },
    validationCheckbox: function(instance){
      if((instance != null || instance != undefined) && this.model.required) {
        if(instance.length < 1 ){
          this.buildError(false, "Necessário selecionar um item da lista");
        }
      }
      this.getState();
      // if(this.$props.vModel.status && this.$props.callback != undefined)
      //   this.$props.callback();

    },
    validationSelectTwo : function(instance){
      if((instance != null || instance != undefined) && this.model.required) {
        this.buildError(false, "Necessário selecionar um item da lista");
      }
      this.getState();
      if(this.$props.vModel.status && this.$props.callback != undefined)
        this.$props.callback();

    },
    validationInput: function() {
      if (
        this.$props.vModel.value == null ||
        this.$props.vModel.value == undefined
      )
        return;

      let re;
      let v;

      switch (this.$props.validationType) {
        case "email":
          re = /[-.\w]+@([\w-]+\.)+[\w-]{2,20}/;

          if (!re.test(this.$props.vModel.value)) {
            this.buildError(false, "E-mail inválido");
          } else if (this.$props.vModel.value.length > 50) {
            this.buildError(false, "Máximo de 50 caracteres");
          } else {
            this.buildError(true, null);
          }
          break;
        case "cpf":
          v = this.$props.vModel.value;
          v = this.clearString(v);
          if (!this.testCpf(v)) {
            this.buildError(false, "O CPF preenchido é inválido");
          } else {
            this.buildError(true, null);
          }
          break;
        case "cep":
          if (this.$props.vModel.value.length < 8){
            this.buildError(false, "O CEP preenchido é inválido");
          } else {
            this.buildError(true, null);
          }
          break;   
        case "cnpj":
          v = this.$props.vModel.value;
          v = this.clearString(v);
          if (!this.testCnpj(v)) {
            this.buildError(false, "O cnpj preenchido é inválido");
          } else {
            this.buildError(true, null);
          } 
          break;       
        case "date":
              re = /([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}/;
              v = this.$props.vModel.value;
              // Verifica se data é inválida
              if (!re.test(v)) {
                  this.buildError(false,'Data inválida');
              } else {
                  // Caso seja válida, verifica se é uma data futura
                  const date = v.split('/')
                  const inputDate = new Date(`${date[1]}/${date[0]}/${date[2]}`); // MM/DD/YYYY
                  const todayDate = new Date();

                  // Seta as horas para não serem consideradas na comparação
                  if(inputDate.setHours(0,0,0,0) > todayDate.setHours(0,0,0,0)) {
                      this.buildError(false, "Não é permitido adicionar uma data futura");
                  } else {
                      this.buildError(true,null);
                  }
              }
          break;          
      }


      this.getState();
      if(this.state && this.$props.callback != undefined)
        this.$props.callback();
    },
    buildError: function(sta, message) {
      this.messageValidation = message;
      //this.$props.vModel.ChangeStatus(sta);
      this.$props.vModel.status = sta;
      this.model.status = sta;
      this.state = sta;
    },
    clearString: function(str) {
      return str.replace(/[^\d]/g, "");
    },
    isNullOrEmpty: function(value) {
      return !(
        !value ||
        value == undefined ||
        value == "" ||
        value.length == 0 
      );
    },
    testCnpj: function(c) {
      var b = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2];

      if ((c = c.replace(/[^\d]/g, "")).length != 14) return false;

      if (/0{14}/.test(c)) return false;

      let i = 0;
      let n = 0;
      for (i = 0, n = 0; i < 12; n += c[i] * b[++i]);
      if (c[12] != ((n %= 11) < 2 ? 0 : 11 - n)) return false;

      for (i = 0, n = 0; i <= 12; n += c[i] * b[i++]);
      if (c[13] != ((n %= 11) < 2 ? 0 : 11 - n)) return false;

      return true;
    },
    testCpf: function(cpf) {
      var numbers, digits, sum, i, result, similar_digits;

      similar_digits = 1;

      if (cpf.length < 11) return false;

      for (i = 0; i < cpf.length - 1; i++)
        if (cpf.charAt(i) != cpf.charAt(i + 1)) {
          similar_digits = 0;
          break;
        }

      if (!similar_digits) {
        numbers = cpf.substring(0, 9);
        digits = cpf.substring(9);
        sum = 0;
        for (i = 10; i > 1; i--) sum += numbers.charAt(10 - i) * i;
        result = sum % 11 < 2 ? 0 : 11 - (sum % 11);
        if (result != digits.charAt(0)) return false;
        numbers = cpf.substring(0, 10);
        sum = 0;
        for (i = 11; i > 1; i--) sum += numbers.charAt(11 - i) * i;
        result = sum % 11 < 2 ? 0 : 11 - (sum % 11);
        if (result != digits.charAt(1)) return false;
        return true;
      } else return false;
    }
  },
  mounted() {
  
  }
};
</script>
<style scoped>
.required-label {
  color: red;
}
</style>