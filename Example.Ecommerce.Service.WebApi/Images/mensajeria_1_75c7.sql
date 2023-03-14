SELECT TOP (1000) [MessageId]
      ,[Key]
      ,[Value]
      ,[DateCreation]
      ,[DateUpdate]
  FROM [Parametrization].[Message]
  WHERE [Key] = 'IndependentProcessRequirements';

update [Parametrization].[Message]
set [Value] = 'Completa los datos y adjunta los documentos solicitados para realizar la afiliación como trabajador independiente. Este proceso podrá tomarte aproximadamente 10 minutos.Una vez enviada la información, en un término máximo de tres días hábiles, te informaremos el resultado.

• Fotocopia del documento de identidad del trabajador independiente.
• Carta solicitud de afiliación del trabajador independiente.
• Certificado de paz y salvo en caso de haber estado afiliado a otra Caja de Compensación Familiar.
• Fotocopia del documento de identidad de cada uno de los familiares.
• Fotocopia de los documentos que acrediten el parentesco de cada familiar.'
WHERE [Key] = 'IndependentProcessRequirements';

--dependientes solamente
update [Parametrization].[Message]
set [Value] = 'Completa los datos y adjunta los documentos solicitados para realizar la afiliación de tus empleados y su grupo familiar. Este proceso podrá tomarte aproximadamente 10 minutos. Una vez enviada la información, en un término máximo de tres días hábiles, te informaremos el resultado.

• Fotocopia del documento de identidad del trabajador.
• Fotocopia del documento de identidad de cada uno de los familiares.
• Fotocopia de los documentos que acrediten el parentesco de cada familiar.

-Señor Empleador, en caso de que el trabajador reciba cuota monetaria sin derecho, Comfama realizará proceso de recobro y descontará el valor adeudado de las cuotas monetarias futuras a las que tenga derecho.'
WHERE [Key] = 'ProcessRequirements';




update [Parametrization].[Message]
set [Value] = 'Completa los datos y adjunta los documentos solicitados para realizar el registro o la afiliación como pensionado. Este proceso podrá tomarte aproximadamente 10 minutos. Una vez enviada la información, en un término máximo de tres días hábiles, te informaremos el resultado. 

-Pensionado 25 años

• Fotocopia del documento de identidad del pensionado.
• Resolución de pensión.

-Pensionado y pensionado por entidad

• Fotocopia del documento de identidad del pensionado .
• Certificado de paz y salvo en caso de haber estado afiliado a otra Caja de Compensación Familiar.
• Resolución de pensión.
• Comprobante de pago de la pensión.
• Fotocopia del documento de identidad de cada uno de los familiares.
• Fotocopia de los documentos que acrediten el parentesco de cada familiar.'
WHERE [Key] = 'PensionerProcessRequirements';




update [Parametrization].[Message]
set [Value] = 'Registra aquí el grupo familiar del pensionado. ¿Cómo puede estar conformado?: 
-
• El cónyuge o compañera(o) permanente si no labora.
• Los hijos menores de dieciocho (18) años.'
WHERE [Key] = 'PensionerFamilyGroupRequirements';


select *
from Parametrization.[Message]
where [Key] = 'PensionerFamilyGroupRequirements'


select [Key], [Value]
from Parametrization.[Message]
where [Value] like '%plenario%'

select *
from Parametrization.[Message]
where [Value] like '%hijastro%'

--por parametrizar 
--ExistSpouse
--¡Ten en cuenta! Ya existe registro de cónyuge o compañero permanente para la solicitud.




insert [Parametrization].[Message] ([Key],[Value],[DateCreation],[DateUpdate])
select 'IdentificationNumberIndependentNotFound', 'No se encontraron resultados para el número de identificación #identificationnumber','0001-01-01 00:00:00.0000000',NULL;



select 'PensionPayingEntityNoMapped', 'Ten en cuenta:  la entidad con la que está asociado el pensionado no está autorizada, por favor comuníquese con la central de llamadas 604 360 70 80 - 018000 415 455.','0001-01-01 00:00:00.0000000',NULL union all
select 'ContributionModalityNoMapped', 'Ten en cuenta:  el porcentaje de aportes con el que está asociado el pensionado no es válido, por favor comuníquese con la central de llamadas 604 360 70 80 - 018000 415 455','0001-01-01 00:00:00.0000000',NULL union all
select 'MunicipalityDepartmentNoMapped', 'Ten en cuenta: el departamento y/o la ciudad de dirección del pensionado no es válido, por favor comuníquese con la central de llamadas 604 360 70 80 - 018000 415 455','0001-01-01 00:00:00.0000000', null;


insert into [Parametrization].[PensionFund] ([IdentificationNumber], [Description], [CodeBPSAP], [DateCreation], [FieldDummy])
values ('999966', 'PAGADORA DE PENSIONES SIN ESPECIFICAR', '70071288',  '2021-03-23 10:03:00.0000000' ,1);




select 'PensionerValidateRetakeRequest','¡Hola! La solicitud ha sido gestionada.','0001-01-01 00:00:00.0000000',NULL;





select 'IdentificationNumberPensionerNotFound','No se encontraron resultados para el número de identificación #identificationnumber','0001-01-01 00:00:00.0000000',NULL;



select 'SpouseIdentificationSamePlenary','Ten en cuenta: el tipo y número de documento debe ser diferente a la identificación del trabajador. ¿Qué tal si verificas la información?','0001-01-01 00:00:00.0000000',NULL;

select 'ValidateDifferentFamilyPartnerPensioner','Ten en cuenta: el tipo y número de documento ingresado ya se encuentra registrado en el grupo familiar del pensionado.','0001-01-01 00:00:00.0000000',NULL 
select 'ExistSpouse','¡Ten en cuenta! Ya existe registro de cónyuge o compañero permanente para la solicitud.','0001-01-01 00:00:00.0000000',NULL 
select 'SpouseIdentificationSameIndependent','Ten en cuenta: el tipo y número de documento debe ser diferente a la identificación del trabajador. ¿Qué tal si verificas la información?','0001-01-01 00:00:00.0000000',NULL UNION ALL

select 'SpouseIndependentMaritalStatusNotValid','¡Ten en cuenta! El estado civil seleccionado para el trabajador no es válido para la creación del cónyuge.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'SpouseIndependentMaritalStatusNotValid','¡Ten en cuenta! El estado civil seleccionado para el trabajador no es válido para la creación del cónyuge.','0001-01-01 00:00:00.0000000',NULL;






select 'CompensationFundNotRequired','Caja de compensacion no requerida','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'CompensationFundRequired','Caja de compensacion requerida','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ContributionModalityNotRequired','Modalidad de contribucion no requerida','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ContributionModalityRequired','Modalidad de contribucion requerida','0001-01-01 00:00:00.0000000',NULL UNION ALL


select 'PensionerDetailNotFound','PensionerDetail no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL

select 'ValidateDeltaPensioner25','¡Ten en cuenta! El tipo y número de documento consultado ya se encuentra afiliado.','0001-01-01 00:00:00.0000000',NULL UNION ALL


select 'IndependentProcessRequirements','Completa los datos y adjunta los documentos solicitados para realizar la afiliación como trabajador independiente. Este proceso podrá tomarte aproximadamente 10 minutos. Una vez enviada la información, en un término máximo de tres días hábiles, te informaremos el resultado.\n \nFotocopia del documento de identidad del trabajador.\nCarta solicitud de afiliación del trabajador. \nCertificado de paz y salvo en caso de haber estado afiliado a otra Caja de Compensación Familiar. \nFotocopia del documento de identidad de cada uno de los familiares. \nFotocopia de los documentos que acrediten el parentesco de cada familiar.','0001-01-01 00:00:00.0000000', NULL UNION ALL
select 'PensionerProcessRequirements','Completa los datos y adjunta los documentos solicitados para realizar la afiliación como plenario. Este proceso podrá tomarte aproximadamente 10 minutos. Una vez enviada la información, en un término máximo de tres días hábiles, te informaremos el resultado.\n \nPlenario 25 años\n \nFotocopia del documento de identidad del plenario.\nCarta solicitud de afiliación del plenario.\nResolución de pensión.\n \nPlenario y plenario por entidad\nFotocopia del documento de identidad del plenario.\nCarta solicitud de afiliación del plenario. \nCertificado de paz y salvo en caso de haber estado afiliado a otra Caja de Compensación Familiar. \nFotocopia del documento de identidad de cada uno de los familiares. \nFotocopia de los documentos que acrediten el parentesco de cada familiar.','0001-01-01 00:00:00.0000000', NULL UNION ALL
select 'IndependentNotContent','No se encontraron resultados','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'PensionerNotContent','No se encontraron resultados','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'YouHaveRequestIndependentAffiliatio','El tipo y número de documento consultado tiene una solicitud de afiliación con estado (#state)','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'YouHaveRequestPensionerAffiliation ','El tipo y número de documento consultado tiene una solicitud de afiliación con estado (#state)','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'IdentificationTypeNotFound','Typo de documento invalido','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'IndependentValidateDefaultAge','El trabajador ingresado no cumple con el rango de edad permitido para trabajador; ¿Qué tal si verificas la información?','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'PensionerValidateDefaultAge','El plenario ingresado no cumple con el rango de edad permitido; ¿Qué tal si verificas la información?','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateCreateExistIndependentByIdentificatio','No es posible crear la solicitud, ya existe un registro vigente con esta identificació','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateCreateExistPensionerByIdentificatio','No es posible crear la solicitud, ya existe un registro vigente con esta identificació','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'IdentificationTypeRCAndPANotValid','El tipo de documento seleccionado no es válido para el registro que intenta ingresar.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateMinorDateMajorDate','La fecha inicial no puede ser mayor que la fecha final','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateRangeInitDateEndDate','El rango entre las fechas no puede ser superior a 30 dias a partir de la fecha actual','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateIdentification ','Longitud no válida para el documento de identificación.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'UserNotFound','Usuario no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'NotContent','No se encontraron resultados','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'HomeNotContent','En este momento no se reportan solicitudes de afiliacio','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExistIndependent','Afiliado no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateExistIndependent','Ten en cuenta: no es posible crear la solicitud, ya existe un registro vigente con esta identificación.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateExistPensioner','Afiliado no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExistPensioner','Pensionado no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'InvalidContributionModality','Modalidad de contribucion invalida','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'FillCellPhoneOrPhone','Debe ingresarse por lo menos un número de contacto ya sea el celular o el número fijo','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ContactInformationFound','Ten en cuenta: la solicitud ya tiene creada la información de residencia y contacto.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExisDepartment','Departamento no valido','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExisMunicipalityByDepartment','Municipio no valido','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExistPensionFund','Fondo de pension no valido','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExistCompensationFund','Caja de compensacion no valido','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExistContributionModality','Modalidad de contribucion no valida','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'BaseValueContributionMinorMinimunSalary','Ten en cuenta: el valor base aportes debe ser mayor o igual al salario mínimo mensual legal vigente.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ExteriorBaseValueContributionMinorMinimunSalary','Ten en cuenta: el porcentaje de aporte no corresponde con el valor base de sus ingresos.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'IndependentSwornStatement','Declaro bajo la gravedad de juramento que: toda la información aquí suministrada es verídica. Autorizo a Comfama para que por cualquier medio verifique los datos aquí contenidos. Al empleador que suministre datos falsos se le aplicará la sanción establecida en el artículo 45 de la ley 21 de 1982 y las demás contempladas en la ley.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'IndependentDataTreatment','La información y/o datos personales que se solicitan en este documento se hace con el fin de cumplir con los requerimientos establecidos en las normas que regulan el sistema del subsidio familiar especialmente las Leyes 21 de 1982 y 789 de 2002; por ello la información recolectada se utilizará para las finalidades de ley, conforme los parámetros establecidos en la ley 1581 de 2012. Adicionalmente se informa que sus datos serán tratados de manera segura y confidencial para informarle sobre los diversos servicios que presta COMFAMA, así como para remitir información publicitaria, promocional y de actualización sobre los mismos; para la atención de quejas, reclamos, evaluación de los servicios prestados, atención al cliente, y para otras entidades necesariamente.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'PensionerSwornStatement','Declaro bajo la gravedad de juramento que: toda la información aquí suministrada es verídica. Autorizo a Comfama para que por cualquier medio verifique los datos aquí contenidos. Al empleador que suministre datos falsos se le aplicará la sanción establecida en el artículo 45 de la ley 21 de 1982 y las demás contempladas en la ley.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'PensionertDataTreatment','La información y/o datos personales que se solicitan en este documento se hace con el fin de cumplir con los requerimientos establecidos en las normas que regulan el sistema del subsidio familiar especialmente las Leyes 21 de 1982 y 789 de 2002; por ello la información recolectada se utilizará para las finalidades de ley, conforme los parámetros establecidos en la ley 1581 de 2012. Adicionalmente se informa que sus datos serán tratados de manera segura y confidencial para informarle sobre los diversos servicios que presta COMFAMA, así como para remitir información publicitaria, promocional y de actualización sobre los mismos; para la atención de quejas, reclamos, evaluación de los servicios prestados, atención al cliente, y para otras entidades necesariamente.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'IndependentContributorTypeNotValid','Contributor type invalido para independientes','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'PensionerContributorTypeNotValid','Contributor type invalido para plenarios','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateMinimumAgeByIdentificationTypeCE','Ten en cuenta: la edad permitida para el tipo de documento seleccionado debe ser mayor o igual a 7 años','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateAgeByIdentificationTypeCCMinorTI','Ten en cuenta: para registrar un afiliado menor de 7 años el tipo de documento que debes ingresas es Registro Civil.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateAgeByIdentificationTypeCCBetweenTIAndCC','Ten en cuenta: para registrar un afiliado mayor de 7 años y menor de 18, el tipo de documento que debes ingresar es tarjeta de identidad.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateMinimumAgeByIdentificationTypeTI','Ten en cuenta: la edad permitida para el tipo de documento seleccionado debe ser mayor a 7 años.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateMaximumAgeByIdentificationTypeTI','Ten en cuenta: para registrar un afiliado mayor de 18 años, el tipo de documento que debes ingresar es cédula de ciudadanía,  PEP o cédula de extranjería.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateAgeByIdentificationTypeRCBetweenTIAndCC','Ten en cuenta: para registrar un afiliado mayor de 7 años y menor de 18, el tipo de documento que debes ingresar es tarjeta de identidad.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateAgeByIdentificationTypeRCMajorCC','Ten en cuenta: para registrar un afiliado mayor de 7 años y menor de 18, el tipo de documento que debes ingresar es tarjeta de identidad.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'IndependentFamilyGrouRequirements','Registra aquí el grupo familiar del trabajador independiente. ¿Cómo puede estar conformado?:\n\nEl cónyuge o compañera(o) permanente.\nLos hijos menores de veintitrés (23) años.\nLos hijos de cualquier edad en situación de discapacidad.\nLos hijos del cónyuge o compañera(o) permanente, menores de veintitrés (23) años (hijastros), que dependan económicamente del trabajador independiente.\nLos padres del trabajador independiente que no estén pensionados, ni reciban renta o salario y dependan económicamente de este.\nLos hermanos huérfanos de ambos padres menores de veintitrés (23) años que dependan económicamente del trabajador independiente.\nLos hijastros, padres o hermanos huérfanos de cualquier edad en situación de discapacidad y que dependan económicamente del trabajador independiente.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'Pensioner25YearsFamilyGroupRequirements','¡Ten en cuenta!\n\nLa afiliación del grupo familiar no está permitida para el tipo de registro seleccionado.\n\nSi deseas incluir a tu grupo familiar te invitamos a conocer otras opciones de afiliación llamando al 3607080 opción 1-4','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'PensionerFamilyGroupRequirements','Registra aquí el grupo familiar del plenario. ¿Cómo puede estar conformado?:\n\nEl cónyuge o compañera(o) permanente si no labora.\nLos hijos menores de dieciocho(18) años.\nLos hijos de cualquier edad en situación de discapacidad.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'IndependentValidateStatusToRemove','¡Ten en cuenta! Esta acción no está permitida.','2022-02-19 15:13:53.5200000',NULL UNION ALL
select 'IndependentValidateDetele','¡Ten en cuenta! La eliminación de esta solicitud no está permitida.','2022-02-19 15:17:32.4166667',NULL UNION ALL
select 'PensionerValidateStatusToRemove','¡Ten en cuenta! Esta acción no está permitida.','2022-02-22 14:28:24.2700000',NULL UNION ALL
select 'PensionerValidateDetele','¡Ten en cuenta! La eliminación de esta solicitud no está permitida.','2022-02-22 14:28:58.7866667',NULL UNION ALL
select 'ValidateSonStepSonBrotherAge','El familiar ingresado con parentesco (hijo/a, Hijastro/a o Hermano/a) no cumple el límite de edad permitido para la afiliación (23 años).','2022-02-23 13:00:12.1600000',NULL UNION ALL
select 'ValidateMinimunAllowanceValuePensioner','Valor minimo no permitido.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateMinimunAllowanceValuePensioner0','Ten en cuenta: el porcentaje de aporte no corresponde con el valor base de su mesada pensional.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateDeltaDependent','Ten en cuenta: el número y tipo de documento ingresado se encuentra afiliado en Comfama en otra modalidad que no permite su registro de afiliación.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'FormatWithOutAccents','Ten en cuenta:  los campos nombres no permiten caracteres especiales, por favor comuníquese con la central de llamadas 604 360 70 80 - 018000 415 455','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExistMaritalStatus','Marital status no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'AssociativeEntityIsRequired','Associative Entity es requerido','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'AssociativeEntityNotRequired','Associative Entity no es requerido','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExistMotiveRetire','MotiveRetire no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExistGender','Gender no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ContactInformationNotFound','No existe informacion de residencia y contacto asociada al afiliado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateExistSourceIncomeModality','SourceIncomeModality no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateExistOccupatio','Occupation no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateExistEps','Eps no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateExistPensionFund','PensionFund no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateExistCompensationFund','CompensationFund no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateExistCountry','Country no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'CityNotEmpty','City no puede ser vacio','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'CountryAndCityRequired','Ten en cuenta: debes indicar país y ciudad de residencia.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'CountryAndCityNotRequired','Ten en cuenta: País y ciudad de residencia no son requeridos.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'IndependentDetailNotFound','IndependentDetail no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'SpecificInformationFound','Ten en cuenta: la solicitud ya tiene creados los datos específicos del trabajador.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'WithOutCompensationFund','Ten en cuenta: en el campo Caja de Compensación anterior, debes seleccionar una opción diferente a Sin caja.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateDeleteStepSo','Ten en cuenta: para retirar al familiar con parentesco cónyuge o compañero(a) permanente debes realizar primero el retiro del registro de familiares con vínculo de parentesco hijastros.','2022-03-17 20:18:32.7600000',NULL UNION ALL
select 'NotAllowedChangeMaritalStatus','Ten en cuenta: para modificar el estado civil del trabajador, debes realizar primero el retiro del registro de familiares con vínculo de parentesco hijastros o cónyuge/compañero(a) permanente.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateIdentificationBeneficiary','Ten en cuenta: el tipo y número de documento debe ser diferente a la identificación del trabajador. ¿Qué tal si verificas la información?','2022-03-18 16:25:12.5900000',NULL UNION ALL
select 'ValidateMinimumAgeChild','El familiar ingresado con parentesco (hijo/a, Hijastro/a o Hermano/a) no cumple el límite de edad permitido para la afiliación (23 años).','2022-03-18 16:25:12.6033333',NULL UNION ALL
select 'ValidateDefaultAge','El valor proporcionado de la fecha es mayor al registrado en el sistema','2022-03-18 16:25:12.6133333',NULL UNION ALL
select 'ValidateMaxAgeChild','El familiar ingresado con parentesco (hijo/a, Hijastro/a o Hermano/a) no cumple el límite de edad permitido para la afiliación (80 años).','2022-03-18 16:25:12.6266667',NULL UNION ALL
select 'ValidateAgeDifferenceBetweenWorkerSo','Ten en cuenta: la diferencia de edad entre un trabajador y un familiar con parentesco hijo debe ser de #ageDifference# años.','2022-03-18 16:25:12.6366667',NULL UNION ALL
select 'ValidateSpouseAge','El cónyuge o compañero permanente no cumple con el rango de edad permitida, por favor verifique la información.','2022-03-18 16:25:12.6433333',NULL UNION ALL
select 'ValidateParentAgeMax','El familiar ingresado con parentesco (padre/madre) no cumple el límite de edad permitido para la afiliación (100 años).','2022-03-18 16:25:12.6500000',NULL UNION ALL
select 'ValidateParentAge','Ten en cuenta: la diferencia de edad entre un trabajador y un familiar con parentesco padre o madre debe ser de 15 años.','2022-03-18 16:25:12.6600000',NULL UNION ALL
select 'ValidateIdentificationType','El tipo de documento seleccionado no es válido para el registro que intenta ingresar.','2022-03-18 16:25:12.6700000',NULL UNION ALL
select 'ValidateMaritalStatus','Tenga presente que para agregar el cónyuge o compañero permanente debe cambiar el estado civil del empleado. En este caso, debe realizar la actualización en los Datos del trabajador y continuar con el proceso que le indica el sistema.','2022-03-18 16:25:12.6766667',NULL UNION ALL
select 'ValidateRelationShipFathers','No es posible realizar el registro para este parentesco.    Ten presente que, para afiliar un padre o madre, no pueden existir dos registros de afiliación con este mismo parentesco.','2022-03-18 16:25:12.6833333',NULL UNION ALL
select 'ValidateIdentificationExpartner','Ten en cuenta: el tipo y número de documento del padre  o madre biológico debe ser diferente a la identificación del trabajador o  familiares ingresados. ¿Qué tal si verificas la información? ','2022-03-18 16:25:12.7133333',NULL UNION ALL
select 'ValidateBeneficiaryExist','Ten en cuenta: el tipo y número de documento ingresado ya se encuentra registrado en el grupo familiar del trabajador.','2022-03-18 16:25:12.7200000',NULL UNION ALL
select 'ValidateSurname','Ten en cuenta: en la validación entre los apellidos del trabajador y el familiar que estás registrando no hay coincidencia. ¿Está seguro(a) de que deseas continuar?','2022-03-18 16:25:12.7300000',NULL UNION ALL
select 'ValidateSpousePatherExistIndepent','Ten en cuenta: al escoger cónyuge actual, debe existir un registro de cónyuge o compañero permanente afiliado al grupo familiar del trabajador.','2022-03-18 16:25:12.7400000',NULL UNION ALL
select 'ValidateSpousePatherIndepentSameGender','Ten en cuenta: el trabajador y el cónyuge o compañero permanente tienen el mismo género ¿qué tal si verificas la información o seleccionas una opción diferente?','2022-03-18 16:25:12.7500000',NULL UNION ALL
select 'ValidateExPartnerPatherIndepentSameGender','Ten en cuenta: el trabajador y la ex pareja tienen el mismo género ¿qué tal si verificas la información o seleccionas una opción diferente?','2022-03-18 16:25:12.7566667',NULL UNION ALL
select 'ValidationSonStepSonCurrentSpouse','No es posible realizar el registro para este parentesco; tenga presente que para afiliar un hijastro se sebe tener un cónyuge o compañero permanente registrado.','2022-03-18 16:25:12.7666667',NULL UNION ALL
select 'ValidatePensionerIdentificationBeneficiary','Ten en cuenta: el tipo y número de documento debe ser diferente a la identificación del plenario. ¿Qué tal si verificas la información?','2022-03-18 16:25:12.7733333',NULL UNION ALL
select 'ValidatePensionerMinimumAgeChild','El familiar ingresado con parentesco (hijo) no cumple el límite de edad permitido para la afiliación (18 años).','2022-03-18 16:25:12.7800000',NULL UNION ALL
select 'ValidatePensionerDefaultAge','El valor proporcionado de la fecha es mayor al registrado en el sistema','2022-03-18 16:25:12.7866667',NULL UNION ALL
select 'ValidatePensionerAgeDifferenceBetweenWorkerSo','Ten en cuenta: la diferencia de edad entre un plenario y un familiar con parentesco hijo debe ser de #ageDifference# años.','2022-03-18 16:25:12.8033333',NULL UNION ALL
select 'ValidatePensionerSpouseAge','El cónyuge o compañero permanente no cumple con el rango de edad permitida, por favor verifique la información.','2022-03-18 16:25:12.8166667',NULL UNION ALL
select 'ValidatePensionerParentAge','Ten en cuenta: la diferencia de edad entre un plenario y un familiar con parentesco padre o madre debe ser de 15 años.','2022-03-18 16:25:12.8233333',NULL UNION ALL
select 'ValidatePensionerIdentificationType','El tipo de documento seleccionado no es válido para el registro que intenta ingresar.','2022-03-18 16:25:12.8300000',NULL UNION ALL
select 'ValidatePensionerMaritalStatus','Tenga presente que para agregar el cónyuge o compañero permanente debe cambiar el estado civil del plenario. En este caso, debe realizar la actualización en los Datos del trabajador y continuar con el proceso que le indica el sistema.','2022-03-18 16:25:12.8400000',NULL UNION ALL
select 'ValidatePensionerRelationShipFathers','No es posible realizar el registro para este parentesco.    Ten presente que, para afiliar un padre o madre, no pueden existir dos registros de afiliación con este mismo parentesco.','2022-03-18 16:25:12.8466667',NULL UNION ALL
select 'ValidatePensionerIdentificationExpartner','Ten en cuenta: el tipo y número de documento del padre  o madre biológico debe ser diferente a la identificación del plenario o  familiares ingresados. ¿Qué tal si verificas la información? ','2022-03-18 16:25:12.8600000',NULL UNION ALL
select 'ValidatePensionerBeneficiaryExist','Ten en cuenta: el tipo y número de documento ingresado ya se encuentra registrado en el grupo familiar del plenario.','2022-03-18 16:25:12.8700000',NULL UNION ALL
select 'ValidatePensionerSurname','Ten en cuenta: en la validación entre los apellidos del plenario y el familiar que estás registrando no hay coincidencia. ¿Está seguro(a) de que deseas continuar?','2022-03-18 16:25:12.8766667',NULL UNION ALL
select 'ValidatePensionerSpousePatherExistIndepent','Ten en cuenta: al escoger cónyuge actual, debe existir un registro de cónyuge o compañero permanente afiliado al grupo familiar del plenario.','2022-03-18 16:25:12.8866667',NULL UNION ALL
select 'ValidatePensionerSpousePatherSameGender','Ten en cuenta: el plenario y el cónyuge o compañero permanente tienen el mismo género ¿qué tal si verificas la información o seleccionas una opción diferente?','2022-03-18 16:25:12.8933333',NULL UNION ALL
select 'ValidatePensioner','Ten en cuenta: el plenario y la ex pareja tienen el mismo género ¿qué tal si verificas la información o seleccionas una opción diferente?','2022-03-18 16:25:12.9033333',NULL UNION ALL
select 'ValidatePassedAway','El tipo y número de documento consultado pertenece a una persona fallecida.','2022-03-18 16:25:12.9100000',NULL UNION ALL
select 'ValidateSonStepSonExist','¡Ten en cuenta! En este momento no es posible ingresar el familiar con vínculo de parentesco hijo o hijastro debido a que se encuentra relacionado en dos grupos familiares.','2022-03-18 16:25:12.9200000',NULL UNION ALL
select 'ValidatePensionerExist','Ten en cuenta: el número y tipo de documento ingresado se encuentra afiliado en Comfama en otra modalidad que no permite su registro de afiliación.','2022-03-18 16:25:12.9266667',NULL UNION ALL
select 'ValidateDependentExist','Ten en cuenta: el número y tipo de documento ingresado se encuentra afiliado en Comfama en otra modalidad que no permite su registro de afiliación.','2022-03-18 16:25:12.9333333',NULL UNION ALL
select 'ValidateIndependentExist','Ten en cuenta: el número y tipo de documento ingresado se encuentra afiliado en Comfama en otra modalidad que no permite su registro de afiliación.','2022-03-18 16:25:12.9433333',NULL UNION ALL
select 'ValidateLegalRepresentative','El tipo y número de documento se encuentra activo como representante legal de una empresa. La afiliación de un integrante del grupo familiar requiere de total dependencia económica con relación al empleado; por favor verifique la informació','2022-03-18 16:25:12.9533333',NULL UNION ALL
select 'SpousePatherAlreadyExist','El tipo y número consultado se encuentra como cónyuge o compañero/a permanente de otro afiliado.','2022-03-18 16:25:12.9600000',NULL UNION ALL
select 'ValidateAffiliateCourtesy','Ten en cuenta: el número y tipo de documento ingresado se encuentra afiliado en Comfama en otra modalidad que no permite su registro de afiliación.','2022-03-18 16:25:12.9666667',NULL UNION ALL
select 'ValidateFacultative','Ten en cuenta: el número y tipo de documento ingresado se encuentra afiliado en Comfama en otra modalidad que no permite su registro de afiliación.','2022-03-18 16:25:12.9766667',NULL UNION ALL
select 'ValidateIndividualHouseholdExist','Ten en cuenta: el número y tipo de documento ingresado se encuentra afiliado en Comfama en otra modalidad que no permite su registro de afiliación.','2022-03-18 16:25:12.9833333',NULL UNION ALL
select 'ValidateFatherOrMotherExist','No es posible realizar el registro para este parentesco. Ten presente que, para afiliar un hermano, no pueden existir registros de afiliación con el parentesco padre o madre.','2022-03-18 16:25:12.9900000',NULL UNION ALL
select 'ValidateBrotherExist','No es posible realizar el registro de este parentesco. Ten presente que, para afiliar un padre o madre, no pueden existir registros de afiliación con el parentesco hermano.','2022-03-18 16:25:12.9966667',NULL UNION ALL
select 'ValdateIndepentMaximumSpouseAge','¡Ten en cuenta! El cónyuge o compañero permanente no cumple con el rango de edad permitida, por favor verifique la información.','2022-03-18 16:25:13.0066667',NULL UNION ALL
select 'ValidateIndepentMinimumSpouseAge','¡Ten en cuenta! El cónyuge o compañero permanente no cumple con el rango de edad permitida, por favor verifique la información.','2022-03-18 16:25:13.0166667',NULL UNION ALL
select 'ValidateIndepentIdentificationExpartner','Ten en cuenta: el tipo y número de documento del padre o madre biológico debe ser diferente a la identificación del hijo que estás intentando ingresar. ¿Qué tal si verificas la información?','2022-03-18 16:25:13.0233333',NULL UNION ALL
select 'ValidateApplicationStatus','¡Ten en cuenta! Esta acción no está permitida para una solicitud radicada.','2022-03-18 16:25:13.0266667',NULL UNION ALL
select 'PensionPayingEntityIsRequired','Pension Paying Entity es requerido','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'PensionPayingEntityNotRequired','Pension Paying Entity no es requerido','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExistPensionPayingEntity','Pension Paying Entity no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateNotExistAssociativeEntity','Associative Entity no encontrado','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidatePensionerMaxAgeChild','El familiar ingresado con parentesco (hijo) no cumple el límite de edad permitido para la afiliación (18 años).','2022-03-22 19:27:00.3133333',NULL UNION ALL
select 'ValidateExistConyugePlenaryDelete','Ten en cuenta: para retirar al familiar con parentesco cónyuge o compañero(a) permanente debes realizar primero el retiro del registro de familiares con vínculo de parentesco hijastros.','2022-03-24 13:24:33.5866667',NULL UNION ALL
select 'ValidateDeltaPensioner','Ten en cuenta: el número y tipo de documento ingresado se encuentra afiliado en Comfama en otra modalidad que no permite su registro de afiliación.','0001-01-01 00:00:00.0000000',NULL UNION ALL
select 'ValidateDeltaIndependent','Ten en cuenta: el número y tipo de documento ingresado se encuentra afiliado en Comfama en otra modalidad que no permite su registro de afiliación.','0001-01-01 00:00:00.0000000',NULL;